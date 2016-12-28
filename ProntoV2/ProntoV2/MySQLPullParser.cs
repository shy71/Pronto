using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;


namespace ProntoV2
{   


    class MySQLPullParser
    {
        //const string tableName = "Product";
        //private String currTag = null;
        //private bool firstTag = true;

        //public String parseXML(Context ctx)
        //{
        //    try
        //    {
        //        string sb = "INSERT INTO " +" " + " VALUES (");

        //        XmlPullParserFactory xppFactory = XmlPullParserFactory.newInstance();
        //        xppFactory.setNamespaceAware(true);
        //        XmlPullParser xpp = xppFactory.newPullParser();

        //        URL yourXmlPath = new URL(url);
        //        InputStream is = yourXmlPath.openConnection().getInputStream();

        //        xpp.setInput(is, null);

        //        int e = xpp.getEventType();
        //        while (e != XmlPullParser.END_DOCUMENT)
        //        {
        //            if (e == XmlPullParser.START_TAG)
        //            {
        //                currTag = xpp.getName();
        //            }
        //            else if (e == XmlPullParser.END_TAG)
        //            {
        //                currTag = null;
        //            }
        //            else if (e == XmlPullParser.TEXT)
        //            {
        //                if (currTag.equals("state"))
        //                {    // first table column
        //                    if (firstTag)
        //                        sb.append(xmlText + "("); // for first row insert
        //                    else
        //                        sb.append(xmlText + ",(");
        //                }

        //                else if (currTagType.equals("district"))
        //                {
        //                    sb.append("'" + xmlText + "')");  // last table column should have a closing paran ")"
        //                }
        //            }
        //            e = xpp.next();
        //        }

        //    }
        //    catch (XmlPullParserException e)
        //    {
        //        e.printStackTrace();
        //    }
        //    catch (IOException e1)
        //    {
        //        e1.printStackTrace();
        //    }

        //    return sb.toString();
        //}
    }
}