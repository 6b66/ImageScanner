using System;
using Windows.Storage;
using Windows.Graphics.Imaging;
using Windows.Media.Ocr;
using System.Text.RegularExpressions;

namespace ImageScanner;

// イメージスキャンするクラス
public static class ImageScanner
{
	private static OcrEngine _engine = OcrEngine.TryCreateFromUserProfileLanguages();

    // 検索を実行する
    // targetは絶対パス
    public static async Task<bool> RecognizeAsync(string targetPath, string targetString, bool caseSensitive, bool useRegex)
	{
		// ファイルのロード
		var file =　await StorageFile.GetFileFromPathAsync(targetPath);
		using var stream = await file.OpenAsync(FileAccessMode.Read);
		var bitmapDecoder = await BitmapDecoder.CreateAsync(stream);
		var targetBitmap = await bitmapDecoder.GetSoftwareBitmapAsync();

		// 画像に含まれる文字を取得
		var imageText = await GetImageText(targetBitmap);

		// 文字列検索
		imageText = Regex.Replace(imageText, @"[\s]+", "");
		var result = useRegex ? Regex.Match(imageText, targetString).Success : imageText.Contains(targetString);
		if (!useRegex && !caseSensitive)
		{
			result = caseSensitive ? result || imageText.Contains(targetString.ToLower()) : result;
			result = caseSensitive ? result || imageText.Contains(targetString.ToUpper()) : result;
		}

        return result;
	}

	private static async Task<string> GetImageText(SoftwareBitmap target)
	{
		try
		{
            var result = await _engine.RecognizeAsync(target);
            return result.Text;
        }
		catch (Exception)
		{
			// 処理途中でキャンセルされると例外になる
			// 対処法がわからないため何もしない
		}
        return "";
    }
}