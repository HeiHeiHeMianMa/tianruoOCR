using System.Web;

namespace TrOCR.Helper
{
    public class TranslateHelper
    {
        public static string BdTrans(string text, string from, string to)
        {
            var url = "http://api.fanyi.baidu.com/api/trans/vip/translate?";
            var appid = IniHelper.GetValue("密钥_百度", "翻译appid");
            var key = IniHelper.GetValue("密钥_百度", "翻译key");
            var salt = CommonHelper.GetTimeSpan(true);
            var query = HttpUtility.UrlEncode(text)?.Replace("+", "%20");
            var sign = GetBdSign(appid, text, salt, key);
            //var data =
            //    $"query={query}&timestamp={salt}&from={from}&imei=20221010001382900&req=v2trans&version=9999&to={to}&trans_mode=3&product=transapp&sign={sign}";
            var data =
                $"q={query}&from={from}&to={to}&appid={appid}&salt={salt}&sign={sign}";
            return CommonHelper.PostData(url, data);
        }

        private static string GetBdSign(string appid, string query, long salt, string key)
        {
            return CommonHelper.Md5($"{appid}{query}{salt}{key}");
        }

        public static string BdTts(string text, string lang, int speed)
        {
            return "";
            /*
            var t = CommonHelper.GetTimeSpan(true);
            var query = HttpUtility.UrlEncode(text);
            var url =
                $"https://fanyi-app.baidu.com/transapp/agent.php?text={query}&os_lang=zh&imei=865166029384834&syslan=zh&type=trans_{lang}&version=9999&timestamp={t}&product=transapp&plat=android&netterm=WIFI&spd={speed}&req=tts&channel=bdguanwang&sign=";
            var sign = GetBdSign("", t, "", "", "tts", text, "");
            return url + sign;*/
        }
    }
}