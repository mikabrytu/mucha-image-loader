using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Mikabrytu.Mucha
{
    public class Mucha
    {
        private const string TAG = "#DOWNLOAD ASYNC#";

        private RawImage image;
        private string url;

        public Mucha load(string url)
        {
            this.url = url;
            return this;
        }

        public Mucha into(RawImage image)
        {
            this.image = image;
            return this;
        }

        public async void start()
        {
            image.texture = await Download(url);
        }

        private async Task<Texture2D> Download(string url)
        {
            using (UnityWebRequest request = UnityWebRequestTexture.GetTexture(url))
            {
                var asyncOp = request.SendWebRequest();

                while (!asyncOp.isDone)
                    await Task.Delay(1000 / 30);

                if (request.isNetworkError || request.isHttpError)
                {
                    Debug.LogError($"{TAG} network error: {request.error} / {request.url}");
                    return null;
                }
                else
                {
                    Debug.Log($"{TAG} thumb downloaded!");
                    return DownloadHandlerTexture.GetContent(request);
                }
            }
        }
    }
}
