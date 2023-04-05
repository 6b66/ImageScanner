using System.Diagnostics;
using System.IO;

namespace ImageScanner
{
    public partial class Form1 : Form
    {
        private static bool running = false;

        public Form1()
        {
            InitializeComponent();

            // リザルトグリッドの設定
            resultGrid.ColumnCount = 1;
            resultGrid.Columns[0].HeaderText = "ファイル名";

            // プログレスバーの設定
            progressBar.Minimum = 0;

            // 画像プレビュー設定
            imagePreview.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // 参照ボタン押下時のイベント
        private void refBtn_Click(object sender, EventArgs e)
        {
            // ファイル選択ダイアログを開く
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // 選択された値をパス入力欄に入れる
                string selectedPath = folderBrowserDialog1.SelectedPath;
                refBox.Text = selectedPath;
            }
        }

        // 検索ボタン押下時のイベント
        private async void searchBtn_Click(object sender, EventArgs e)
        {
            string rootPath = refBox.Text;
            string targetString = searchBox.Text;
            bool caseSensitive = caseSensitive_CheckBox.Checked;
            bool useRegex = useRegex_CheckBox.Checked;

            var imageFileList = GetAllImageFilePath(rootPath);

            running = !running;
            if (imageFileList.Any() && running)
            {
                resultGrid.Rows.Clear();
                progressBar.Maximum = imageFileList.Count - 1;
                // 画像検索を開始
                searchBtn.Text = "キャンセル";
                statusLabel.Text = "状態: 検索中";
                for (int i = 0; i < imageFileList.Count && running; i++)
                {
                    var imageFile = imageFileList[i];
                    var result = await ImageScanner.RecognizeAsync(imageFile, targetString, caseSensitive, useRegex);
                    if (result)
                    {
                        resultGrid.Rows.Add(imageFile);
                    }
                    progressBar.Value = i;
                };
                statusLabel.Text = "状態: 完了";
                searchBtn.Text = "検索";
                running = false;
            }
            else if (!running)
            {
                statusLabel.Text = "状態: 待機";
                searchBtn.Text = "検索";
            }
        }

        // パスに含まれるすべてのpngファイルパスを取得
        private List<string> GetAllImageFilePath(string rootPath)
        {
            return Directory.GetFiles(rootPath, "*.png").ToList();
        }

        // 検索結果の要素をクリックしたとき
        private void resultGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            imagePreview.ImageLocation = resultGrid[e.ColumnIndex, e.RowIndex].Value as string;
        }

        private void imagePreview_Click(object sender, EventArgs e)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(imagePreview.ImageLocation);
            startInfo.Verb = "edit";
            Process.Start(startInfo);
        }
    }
}