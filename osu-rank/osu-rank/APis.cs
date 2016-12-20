﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows;
using Unclassified.TxLib;
using System.Net.Http;
using System.IO;

namespace osurank
{
    // osu!rank related
    public class osu
    {
        static int[] maxIntgr = {int.MaxValue}; 
        // sync
        static public dynamic GetUser(string player, string apikey, int gamemode = 0, bool showErrors = true)
        {
            if (player != "")
            {
                try {
                    dynamic userdata = JsonConvert.DeserializeObject(new System.Net.WebClient().DownloadString("http://osu.ppy.sh/api/get_user?type=string&u=" + player + "&m=" + gamemode + "&k=" + apikey));
                    if (Convert.ToString(userdata) == "[]" || userdata == null)
                    {
                        if (showErrors == true) MessageBox.Show(Tx.T("errors.Does not exist", "name", player), Tx.T("errors.Error"), MessageBoxButton.OK, MessageBoxImage.Error);
                        return maxIntgr;
                    }
                    else if (userdata[0].pp_rank == null)
                    {
                        if (showErrors == true) MessageBox.Show(Tx.T("errors.Did not play yet", "name", player), Tx.T("errors.Error"), MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return maxIntgr;
                    }
                    else return userdata;
                }
                catch (Exception)
                {
                    MessageBox.Show(Tx.T("osu rank.Servers unavailable", "server", "osu!"), Tx.T("errors.Error"), MessageBoxButton.OK, MessageBoxImage.Error);
                    Environment.Exit(0);
                    return maxIntgr;
                }
            }
            else
            {
                if (showErrors == true) MessageBox.Show(Tx.T("errors.No name entered"), Tx.T("errors.Error"), MessageBoxButton.OK, MessageBoxImage.Error);
                return maxIntgr; 
            }
        }

        //async
        static public async Task<dynamic> GetUserAsync(string player, string apikey, int gamemode = 0, bool showErrors = true)
        {
            if (player != "")
            {
                try
                {
                    dynamic userdata = null;
                    using (HttpClient apiCall = new HttpClient())
                    {
                        userdata = JsonConvert.DeserializeObject(await apiCall.GetStringAsync("http://osu.ppy.sh/api/get_user?type=string&u=" + player + "&m=" + gamemode + "&k=" + apikey));
                    }
                    if (Convert.ToString(userdata) == "[]" || userdata == null)
                    {
                        if (showErrors == true) MessageBox.Show(Tx.T("errors.Does not exist", "name", player), Tx.T("errors.Error"), MessageBoxButton.OK, MessageBoxImage.Error);
                        return maxIntgr;
                    }
                    else if (userdata[0].pp_rank == null)
                    {
                        if (showErrors == true) MessageBox.Show(Tx.T("errors.Did not play yet", "name", player), Tx.T("errors.Error"), MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return maxIntgr;
                    }
                    else return userdata;
                }
                catch (Exception)
                {
                    MessageBox.Show(Tx.T("osu rank.Servers unavailable", "server", "osu!"), Tx.T("errors.Error"), MessageBoxButton.OK, MessageBoxImage.Error);
                    Environment.Exit(0);
                    return maxIntgr;
                }
            }
            else
            {
                if (showErrors == true) MessageBox.Show(Tx.T("errors.No name entered"), Tx.T("errors.Error"), MessageBoxButton.OK, MessageBoxImage.Error);
                return maxIntgr;
            }
        }
    }

    public class ripple
    {
        static int[] maxIntgr = { int.MaxValue };
        // sync
        static public dynamic GetUser(string player, int gamemode = 0, bool showErrors = true)
        {
            if (player != "")
            {
                try
                {
                    dynamic userdata = JsonConvert.DeserializeObject(new System.Net.WebClient().DownloadString("http://ripple.moe/api/get_user?type=string&u=" + player + "&m=" + gamemode));
                    if (Convert.ToString(userdata) == "[]" || userdata == null)
                    {
                        if (showErrors == true) MessageBox.Show(Tx.T("errors.Does not exist", "name", player), Tx.T("errors.Error"), MessageBoxButton.OK, MessageBoxImage.Error);
                        return maxIntgr;
                    }
                    else if (userdata[0].pp_rank == null)
                    {
                        if (showErrors == true) MessageBox.Show(Tx.T("errors.Did not play yet", "name", player), Tx.T("errors.Error"), MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return maxIntgr;
                    }
                    else return userdata;
                }
                catch (Exception)
                {
                    MessageBox.Show(Tx.T("osu rank.Servers unavailable", "server", "Ripple"), Tx.T("errors.Error"), MessageBoxButton.OK, MessageBoxImage.Error);
                    Environment.Exit(0);
                    return maxIntgr;
                }
            }
            else
            {
                if (showErrors == true) MessageBox.Show(Tx.T("errors.No name entered"), Tx.T("errors.Error"), MessageBoxButton.OK, MessageBoxImage.Error);
                return maxIntgr;
            }
        }

        //async
        static public async Task<dynamic> GetUserAsync(string player, int gamemode = 0, bool showErrors = true)
        {
            if (player != "")
            {
                try
                {
                    dynamic userdata = null;
                    using (HttpClient apiCall = new HttpClient())
                    {
                        userdata = JsonConvert.DeserializeObject(await apiCall.GetStringAsync("http://ripple.moe/api/get_user?type=string&u=" + player + "&m=" + gamemode));
                    }
                    if (Convert.ToString(userdata) == "[]" || userdata == null)
                    {
                        if (showErrors == true) MessageBox.Show(Tx.T("errors.Does not exist", "name", player), Tx.T("errors.Error"), MessageBoxButton.OK, MessageBoxImage.Error);
                        return maxIntgr;
                    }
                    else if (userdata[0].pp_rank == null)
                    {
                        if (showErrors == true) MessageBox.Show(Tx.T("errors.Did not play yet", "name", player), Tx.T("errors.Error"), MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return maxIntgr;
                    }
                    else return userdata;
                }
                catch (Exception)
                {
                    MessageBox.Show(Tx.T("osu rank.Servers unavailable","server","Ripple"), Tx.T("errors.Error"), MessageBoxButton.OK, MessageBoxImage.Error);
                    Environment.Exit(0);
                    return maxIntgr;
                }
            }
            else
            {
                if (showErrors == true) MessageBox.Show(Tx.T("errors.No name entered"), Tx.T("errors.Error"), MessageBoxButton.OK, MessageBoxImage.Error);
                return maxIntgr;
            }
        }
    }

    // helper
    public static class WebUtils
    {
        public static Task DownloadAsync(string requestUri, string filename)
        {
            if (requestUri == null)
                throw new ArgumentNullException("requestUri");

            return DownloadAsync(new Uri(requestUri), filename);
        }

        public static async Task DownloadAsync(Uri requestUri, string filename)
        {
            if (filename == null)
                throw new ArgumentNullException("filename");

            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, requestUri))
                {
                    using (
                        Stream contentStream = await (await httpClient.SendAsync(request)).Content.ReadAsStreamAsync(),
                        stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
                    {
                        await contentStream.CopyToAsync(stream);
                    }
                }
            }
        }
    }
}
