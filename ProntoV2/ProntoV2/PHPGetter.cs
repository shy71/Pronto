using System.Net;
using System.Text;
using System.IO;
using System;

namespace ProntoV2
{
    public static class PHPGetter
    {
        public static void PHPGet()
        {
            WebClient client = new WebClient();

            client.DownloadFileAsync(new Uri("http://matanyay.vlab.jct.ac.il/Pronto/getPrices.php"), buildTable.getDBPath());
        }

    }

    //public static void PHPGet()
    //{
    //    var webClient = new WebClient();
    //    webClient.DownloadDataCompleted += (s, e) =>
    //    {
    //        var text = e.Result; // get the downloaded file
    //        var outputStream = new StreamWriter(Application.Context.OpenFileOutput("/", FileCreationMode.Private));
    //        outputStream.Write(text);
    //        outputStream.Close();
    //    };
    //    var url = new Uri("http://matanyay.vlab.jct.ac.il/Pronto/getPrices.php"); // Html home page
    //    webClient.DownloadStringAsync(url);
    //}
    //    //File dir = new File(context.getFilesDir(),"ProntoDB.db");
    //    //if (dir.exists() == false)
    //    //{
    //    //    dir.mkdirs();
    //    //}
    //public static void PHPGet();
    //File dir = new File(context.getFilesDir(),"ProntoDB.db");
    //if (dir.exists() == false)

    //{
    //    dir.mkdirs();
    //}

    //URL url = new URL("http://myexample.com/android/");
    //File file = new File(dir, fileName);

    //long startTime = System.currentTimeMillis();
    //Log.d("DownloadManager", "download url:" + url);
    //Log.d("DownloadManager", "download file name:" + fileName);

    //URLConnection uconn = url.openConnection();
    //uconn.setReadTimeout(TIMEOUT_CONNECTION);
    //uconn.setConnectTimeout(TIMEOUT_SOCKET);

    //InputStream is = uconn.getInputStream();
    //BufferedInputStream bufferinstream = new BufferedInputStream(is);

    //ByteArrayBuffer baf = new ByteArrayBuffer(5000);
    //int current = 0;
    //while ((current = bufferinstream.read()) != -1)
    //{
    //    baf.append((byte)current);
    //}

    //FileOutputStream fos = new FileOutputStream(file);
    //fos.write(baf.toByteArray());
    //fos.flush();
    //fos.close();
    //Log.d("DownloadManager", "download ready in" + ((System.currentTimeMillis() - startTime) / 1000) + "sec");
    //int dotindex = fileName.lastIndexOf('.');
    //if (dotindex >= 0)
    //{
    //    fileName = fileName.substring(0, dotindex);

    //}
}
