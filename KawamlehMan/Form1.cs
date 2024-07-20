using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace KawamlehMan
{
    public partial class Form1 : Form
    {
        private readonly HttpClient httpClient;

        public Form1()
        {
            InitializeComponent();
            httpClient = new HttpClient();
            rb_GET.Checked = true;
            InitializeDataGridView(dgv_header);
            InitializeDataGridView(dgv_Params);
        }

        private void InitializeDataGridView(DataGridView dgv)
        {
            dgv.Columns.Add(new DataGridViewButtonColumn()
            {
                Name = "DeleteColumn",
                HeaderText = "",
                Text = "X",
                UseColumnTextForButtonValue = true,
                Width = 30
            });
            dgv.Columns.Add("KeyColumn", "Key");
            dgv.Columns.Add("ValueColumn", "Value");
            dgv.AllowUserToAddRows = true;
            dgv.AllowUserToDeleteRows = true;
            dgv.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            dgv.CellClick += (sender, e) => dgv_CellClick(sender, e, dgv);
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e, DataGridView dgv)
        {
            if (e.ColumnIndex == dgv.Columns["DeleteColumn"].Index && e.RowIndex >= 0 && !dgv.Rows[e.RowIndex].IsNewRow)
            {
                dgv.Rows.RemoveAt(e.RowIndex);
            }
        }

        private async void btn_testAPI_Click(object sender, EventArgs e)
        {
            treeView1.Visible = false;
            webView21.Visible = false;
            pictureBox1.Visible = false;

            string URL = txt_URL.Text;
            if (!IsValidURI(URL))
            {
                MessageBox.Show("URL Is Not Valid");
                return;
            }

            var requestHeaders = GetHeaders();
            var queryString = GetParams();
            string body = requestBody.Text;
            HttpMethod actionVerb = GetActionVerb();

            if (!string.IsNullOrEmpty(queryString))
                URL += $"?{queryString}";

            foreach (var header in requestHeaders)
            {
                httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }

            var request = new HttpRequestMessage(actionVerb, URL);
            if ((actionVerb == HttpMethod.Post || actionVerb == HttpMethod.Put) && !string.IsNullOrEmpty(body))
            {
                request.Content = new StringContent(body, Encoding.UTF8, "application/json");
            }

            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string contentType = response.Content.Headers.ContentType?.MediaType.ToLower();
                string responseContent = await response.Content.ReadAsStringAsync();
                HandleResponse(contentType, responseContent);
            }
            else
            {
                MessageBox.Show("Request failed: " + response.StatusCode);
            }
        }

        private string GetParams()
        {
            var queryString = new StringBuilder();
            bool firstParam = true;

            foreach (DataGridViewRow row in dgv_Params.Rows)
            {
                if (row.IsNewRow) continue;

                string key = row.Cells[1].Value?.ToString();
                string value = row.Cells[2].Value?.ToString();
                if (string.IsNullOrEmpty(key) && string.IsNullOrEmpty(value)) continue;

                if (!firstParam)
                    queryString.Append("&");

                queryString.Append($"{key}={value}");
                firstParam = false;
            }

            return queryString.ToString();
        }

        private Dictionary<string, string> GetHeaders()
        {
            var headers = new Dictionary<string, string>();

            foreach (DataGridViewRow row in dgv_header.Rows)
            {
                if (row.IsNewRow) continue;

                string key = row.Cells[1].Value?.ToString();
                string value = row.Cells[2].Value?.ToString();
                if (string.IsNullOrEmpty(key) && string.IsNullOrEmpty(value)) continue;

                headers.Add(key, value);
            }

            return headers;
        }

        public static bool IsValidURI(string uri)
        {
            return Uri.TryCreate(uri, UriKind.Absolute, out var tmp) &&
                   (tmp.Scheme == Uri.UriSchemeHttp || tmp.Scheme == Uri.UriSchemeHttps);
        }

        private HttpMethod GetActionVerb()
        {
            if (rb_GET.Checked) return HttpMethod.Get;
            if (rb_POST.Checked) return HttpMethod.Post;
            if (rb_PUT.Checked) return HttpMethod.Put;
            if (rb_DELETE.Checked) return HttpMethod.Delete;

            throw new Exception("Action verb not handled");
        }

        private void HandleResponse(string contentType, string responseContent)
        {
            treeView1.Visible = true;

            if (contentType.Contains("application/json"))
            {
                DisplayJsonResponse(responseContent);
            }
            else if (contentType.Contains("xml"))
            {
                DisplayXmlResponse(responseContent);
            }
            else if (contentType.Contains("text/plain"))
            {
                DisplayPlainTextResponse(responseContent);
            }
            else if (contentType.StartsWith("image/"))
            {
                DisplayImage(responseContent);
            }
            else if (contentType == "application/pdf")
            {
                DisplayPdf(responseContent);
            }
            else
            {
                MessageBox.Show("Unsupported file type.");
            }
        }

        private void DisplayJsonResponse(string jsonResponse)
        {
            try
            {
                using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                {
                    treeView1.Nodes.Clear();
                    var rootNode = new TreeNode("JSON Object");
                    treeView1.Nodes.Add(rootNode);
                    AddJsonNodes(rootNode, doc.RootElement);
                }
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"Error parsing JSON: {ex.Message}");
            }
        }

        private void AddJsonNodes(TreeNode parentNode, JsonElement jsonElement)
        {
            switch (jsonElement.ValueKind)
            {
                case JsonValueKind.Object:
                    foreach (JsonProperty prop in jsonElement.EnumerateObject())
                    {
                        var node = new TreeNode(prop.Name);
                        parentNode.Nodes.Add(node);
                        AddJsonNodes(node, prop.Value);
                    }
                    break;

                case JsonValueKind.Array:
                    for (int i = 0; i < jsonElement.GetArrayLength(); i++)
                    {
                        var node = new TreeNode($"[{i}]");
                        parentNode.Nodes.Add(node);
                        AddJsonNodes(node, jsonElement[i]);
                    }
                    break;

                default:
                    parentNode.Nodes.Add(jsonElement.ToString());
                    break;
            }
        }

        public void DisplayXmlResponse(string xmlResponse)
        {
            treeView1.Nodes.Clear();
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(xmlResponse);
                ConvertXmlNodeToTreeNode(doc, treeView1.Nodes);
                treeView1.Nodes[0].ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error parsing XML: {ex.Message}");
            }
        }

        private void ConvertXmlNodeToTreeNode(XmlNode xmlNode, TreeNodeCollection treeNodes)
        {
            var newTreeNode = treeNodes.Add(xmlNode.Name);

            if (xmlNode.NodeType == XmlNodeType.Text || xmlNode.NodeType == XmlNodeType.CDATA)
            {
                newTreeNode.Text = xmlNode.Value;
            }
            else
            {
                newTreeNode.Text = $"<{xmlNode.Name}>";
                foreach (XmlAttribute attribute in xmlNode.Attributes)
                {
                    ConvertXmlNodeToTreeNode(attribute, newTreeNode.Nodes);
                }

                foreach (XmlNode childNode in xmlNode.ChildNodes)
                {
                    ConvertXmlNodeToTreeNode(childNode, newTreeNode.Nodes);
                }
            }
        }

        private void DisplayPlainTextResponse(string plainTextResponse)
        {
            treeView1.Nodes.Clear();
            var rootNode = new TreeNode(plainTextResponse);
            treeView1.Nodes.Add(rootNode);
        }

        private void DisplayImage(string imageResponse)
        {
            try
            {
                var imgBytes = Convert.FromBase64String(imageResponse);
                using (var ms = new System.IO.MemoryStream(imgBytes))
                {
                    var img = Image.FromStream(ms);
                    pictureBox1.Image = img;
                    pictureBox1.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying image: {ex.Message}");
            }
        }

        private async Task DisplayPdf(string pdfResponse)
        {
            try
            {
                var pdfBytes = Convert.FromBase64String(pdfResponse);
                var tempFile = System.IO.Path.GetTempFileName();
                await System.IO.File.WriteAllBytesAsync(tempFile, pdfBytes);

                await webView21.EnsureCoreWebView2Async(null);
                webView21.CoreWebView2.Navigate(tempFile);
                webView21.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying PDF: {ex.Message}");
            }
        }
    }
}
