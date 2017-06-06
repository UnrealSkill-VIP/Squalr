﻿using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TwitchLib.Internal
{
    /// <summary>Class detailing Rfc2812 specifications</summary>
    public sealed class Rfc2812
    {
        // nickname   =  ( letter / special ) *8( letter / digit / special / "-" )
        // letter     =  %x41-5A / %x61-7A       ; A-Z / a-z
        // digit      =  %x30-39                 ; 0-9
        // special    =  %x5B-60 / %x7B-7D
        //                  ; "[", "]", "\", "`", "_", "^", "{", "|", "}"
        private static Regex _NicknameRegex = new Regex(@"^[A-Za-z\[\]\\`_^{|}][A-Za-z0-9\[\]\\`_\-^{|}]+$", RegexOptions.Compiled);

        private Rfc2812()
        {
        }

        /// <summary>
        /// Checks if the passed nickname is valid according to the RFC
        ///
        /// Use with caution, many IRC servers are not conform with this!
        /// </summary>
        public static bool IsValidNickname(string nickname)
        {
            if ((nickname != null) &&
                (nickname.Length > 0) &&
                (_NicknameRegex.Match(nickname).Success))
            {
                return true;
            }

            return false;
        }

        /// <summary>Pass message.</summary>
        public static string Pass(string password)
        {
            return "PASS " + password;
        }

        /// <summary>Nick message.</summary>
        public static string Nick(string nickname)
        {
            return "NICK " + nickname;
        }

        /// <summary>User message.</summary>
        public static string User(string username, int usermode, string realname)
        {
            return "USER " + username + " " + usermode.ToString() + " * :" + realname;
        }

        /// <summary>Oper message.</summary>
        public static string Oper(string name, string password)
        {
            return "OPER " + name + " " + password;
        }

        /// <summary>Privmsg message.</summary>
        public static string Privmsg(string destination, string message)
        {
            return "PRIVMSG " + destination + " :" + message;
        }

        /// <summary>Notice message.</summary>
        public static string Notice(string destination, string message)
        {
            return "NOTICE " + destination + " :" + message;
        }

        /// <summary>Join message.</summary>
        public static string Join(string channel)
        {
            return "JOIN " + channel;
        }

        /// <summary>Join message.</summary>
        public static string Join(string[] channels)
        {
            string channellist = String.Join(",", channels);
            return "JOIN " + channellist;
        }

        /// <summary>Join message.</summary>
        public static string Join(string channel, string key)
        {
            return "JOIN " + channel + " " + key;
        }

        /// <summary>Join message.</summary>
        public static string Join(string[] channels, string[] keys)
        {
            string channellist = String.Join(",", channels);
            string keylist = String.Join(",", keys);
            return "JOIN " + channellist + " " + keylist;
        }

        /// <summary>Part message.</summary>
        public static string Part(string channel)
        {
            return "PART " + channel;
        }

        /// <summary>Part message.</summary>
        public static string Part(string[] channels)
        {
            string channellist = String.Join(",", channels);
            return "PART " + channellist;
        }

        /// <summary>Part message.</summary>
        public static string Part(string channel, string partmessage)
        {
            return "PART " + channel + " :" + partmessage;
        }

        /// <summary>Part message.</summary>
        public static string Part(string[] channels, string partmessage)
        {
            string channellist = String.Join(",", channels);
            return "PART " + channellist + " :" + partmessage;
        }

        /// <summary>Kick message.</summary>
        public static string Kick(string channel, string nickname)
        {
            return "KICK " + channel + " " + nickname;
        }

        /// <summary>Kick message.</summary>
        public static string Kick(string channel, string nickname, string comment)
        {
            return "KICK " + channel + " " + nickname + " :" + comment;
        }

        /// <summary>Kick message.</summary>
        public static string Kick(string[] channels, string nickname)
        {
            string channellist = String.Join(",", channels);
            return "KICK " + channellist + " " + nickname;
        }

        /// <summary>Kick message.</summary>
        public static string Kick(string[] channels, string nickname, string comment)
        {
            string channellist = String.Join(",", channels);
            return "KICK " + channellist + " " + nickname + " :" + comment;
        }

        /// <summary>Kick message.</summary>
        public static string Kick(string channel, string[] nicknames)
        {
            string nicknamelist = String.Join(",", nicknames);
            return "KICK " + channel + " " + nicknamelist;
        }

        /// <summary>Kick message.</summary>
        public static string Kick(string channel, string[] nicknames, string comment)
        {
            string nicknamelist = String.Join(",", nicknames);
            return "KICK " + channel + " " + nicknamelist + " :" + comment;
        }

        /// <summary>Kick message.</summary>
        public static string Kick(string[] channels, string[] nicknames)
        {
            string channellist = String.Join(",", channels);
            string nicknamelist = String.Join(",", nicknames);
            return "KICK " + channellist + " " + nicknamelist;
        }

        /// <summary>Kick message.</summary>
        public static string Kick(string[] channels, string[] nicknames, string comment)
        {
            string channellist = String.Join(",", channels);
            string nicknamelist = String.Join(",", nicknames);
            return "KICK " + channellist + " " + nicknamelist + " :" + comment;
        }

        /// <summary>Motd message.</summary>
        public static string Motd()
        {
            return "MOTD";
        }

        /// <summary>Motd message.</summary>
        public static string Motd(string target)
        {
            return "MOTD " + target;
        }

        /// <summary>Luser message</summary>
        [Obsolete("use Lusers() method instead")]
        public static string Luser()
        {
            return Lusers();
        }

        /// <summary>Luser message.</summary>
        public static string Lusers()
        {
            return "LUSERS";
        }

        /// <summary>Luser message.</summary>
        [Obsolete("use Lusers(string) method instead")]
        public static string Luser(string mask)
        {
            return Lusers(mask);
        }

        /// <summary>Luser message.</summary>
        public static string Lusers(string mask)
        {
            return "LUSER " + mask;
        }

        /// <summary>Luser message.</summary>
        [Obsolete("use Lusers(string, string) method instead")]
        public static string Luser(string mask, string target)
        {
            return Lusers(mask, target);
        }

        /// <summary>Lusers</summary>
        public static string Lusers(string mask, string target)
        {
            return "LUSER " + mask + " " + target;
        }

        /// <summary>Version message.</summary>
        public static string Version()
        {
            return "VERSION";
        }

        /// <summary>Version message.</summary>
        public static string Version(string target)
        {
            return "VERSION " + target;
        }

        /// <summary>Stats message.</summary>
        public static string Stats()
        {
            return "STATS";
        }

        /// <summary>Stats message.</summary>
        public static string Stats(string query)
        {
            return "STATS " + query;
        }

        /// <summary>Stats message.</summary>
        public static string Stats(string query, string target)
        {
            return "STATS " + query + " " + target;
        }

        /// <summary>Links message.</summary>
        public static string Links()
        {
            return "LINKS";
        }

        /// <summary>Links message.</summary>
        public static string Links(string servermask)
        {
            return "LINKS " + servermask;
        }

        /// <summary>Links message.</summary>
        public static string Links(string remoteserver, string servermask)
        {
            return "LINKS " + remoteserver + " " + servermask;
        }

        /// <summary>Time message.</summary>
        public static string Time()
        {
            return "TIME";
        }

        /// <summary>Time message.</summary>
        public static string Time(string target)
        {
            return "TIME " + target;
        }

        /// <summary>Connect message.</summary>
        public static string Connect(string targetserver, string port)
        {
            return "CONNECT " + targetserver + " " + port;
        }

        /// <summary>Connect message.</summary>
        public static string Connect(string targetserver, string port, string remoteserver)
        {
            return "CONNECT " + targetserver + " " + port + " " + remoteserver;
        }

        /// <summary>Trace message.</summary>
        public static string Trace()
        {
            return "TRACE";
        }

        /// <summary>Trace message.</summary>
        public static string Trace(string target)
        {
            return "TRACE " + target;
        }

        /// <summary>Admin message.</summary>
        public static string Admin()
        {
            return "ADMIN";
        }

        /// <summary>Admin message.</summary>
        public static string Admin(string target)
        {
            return "ADMIN " + target;
        }

        /// <summary>Info message.</summary>
        public static string Info()
        {
            return "INFO";
        }

        /// <summary>Info message.</summary>
        public static string Info(string target)
        {
            return "INFO " + target;
        }

        /// <summary>Servlist message.</summary>
        public static string Servlist()
        {
            return "SERVLIST";
        }

        /// <summary>Servlist message.</summary>
        public static string Servlist(string mask)
        {
            return "SERVLIST " + mask;
        }

        /// <summary>Servlist message.</summary>
        public static string Servlist(string mask, string type)
        {
            return "SERVLIST " + mask + " " + type;
        }

        /// <summary>Squery message.</summary>
        public static string Squery(string servicename, string servicetext)
        {
            return "SQUERY " + servicename + " :" + servicetext;
        }

        /// <summary>List message.</summary>
        public static string List()
        {
            return "LIST";
        }

        /// <summary>List message.</summary>
        public static string List(string channel)
        {
            return "LIST " + channel;
        }

        /// <summary>List message.</summary>
        public static string List(string[] channels)
        {
            string channellist = String.Join(",", channels);
            return "LIST " + channellist;
        }

        /// <summary>List message.</summary>
        public static string List(string channel, string target)
        {
            return "LIST " + channel + " " + target;
        }

        /// <summary>List message.</summary>
        public static string List(string[] channels, string target)
        {
            string channellist = String.Join(",", channels);
            return "LIST " + channellist + " " + target;
        }

        /// <summary>Names message</summary>
        public static string Names()
        {
            return "NAMES";
        }

        /// <summary>Names message.</summary>
        public static string Names(string channel)
        {
            return "NAMES " + channel;
        }

        /// <summary>Names message.</summary>
        public static string Names(string[] channels)
        {
            string channellist = String.Join(",", channels);
            return "NAMES " + channellist;
        }

        /// <summary>Names message.</summary>
        public static string Names(string channel, string target)
        {
            return "NAMES " + channel + " " + target;
        }

        /// <summary>Names message.</summary>
        public static string Names(string[] channels, string target)
        {
            string channellist = String.Join(",", channels);
            return "NAMES " + channellist + " " + target;
        }

        /// <summary>Topic message.</summary>
        public static string Topic(string channel)
        {
            return "TOPIC " + channel;
        }

        /// <summary>Topic message.</summary>
        public static string Topic(string channel, string newtopic)
        {
            return "TOPIC " + channel + " :" + newtopic;
        }

        /// <summary>Mode message.</summary>
        public static string Mode(string target)
        {
            return "MODE " + target;
        }

        /// <summary>Mode message.</summary>
        public static string Mode(string target, string newmode)
        {
            return "MODE " + target + " " + newmode;
        }

        /// <summary>Mode message.</summary>
        public static string Mode(string target, string[] newModes, string[] newModeParameters)
        {
            if (newModes == null)
            {
                throw new ArgumentNullException("newModes");
            }
            if (newModeParameters == null)
            {
                throw new ArgumentNullException("newModeParameters");
            }
            if (newModes.Length != newModeParameters.Length)
            {
                throw new ArgumentException("newModes and newModeParameters must have the same size.");
            }

            StringBuilder newMode = new StringBuilder(newModes.Length);
            StringBuilder newModeParameter = new StringBuilder();
            // as per RFC 3.2.3, maximum is 3 modes changes at once
            int maxModeChanges = 3;
            if (newModes.Length > maxModeChanges)
            {
                throw new ArgumentOutOfRangeException(
                    "newModes.Length",
                    newModes.Length,
                    String.Format("Mode change list is too large (> {0}).", maxModeChanges)
                );
            }

            for (int i = 0; i <= newModes.Length; i += maxModeChanges)
            {
                for (int j = 0; j < maxModeChanges; j++)
                {
                    if (i + j >= newModes.Length)
                    {
                        break;
                    }
                    newMode.Append(newModes[i + j]);
                }

                for (int j = 0; j < maxModeChanges; j++)
                {
                    if (i + j >= newModeParameters.Length)
                    {
                        break;
                    }
                    newModeParameter.Append(newModeParameters[i + j]);
                    newModeParameter.Append(" ");
                }
            }
            if (newModeParameter.Length > 0)
            {
                // remove trailing space
                newModeParameter.Length--;
                newMode.Append(" ");
                newMode.Append(newModeParameter.ToString());
            }

            return Mode(target, newMode.ToString());
        }

        /// <summary>Service message.</summary>
        public static string Service(string nickname, string distribution, string info)
        {
            return "SERVICE " + nickname + " * " + distribution + " * * :" + info;
        }

        /// <summary>Invite message.</summary>
        public static string Invite(string nickname, string channel)
        {
            return "INVITE " + nickname + " " + channel;
        }

        /// <summary>Who message.</summary>
        public static string Who()
        {
            return "WHO";
        }

        /// <summary>Who message.</summary>
        public static string Who(string mask)
        {
            return "WHO " + mask;
        }

        /// <summary>Who message.</summary>
        public static string Who(string mask, bool ircop)
        {
            if (ircop)
            {
                return "WHO " + mask + " o";
            }
            else
            {
                return "WHO " + mask;
            }
        }

        /// <summary>Whois message.</summary>
        public static string Whois(string mask)
        {
            return "WHOIS " + mask;
        }

        /// <summary>Whois message.</summary>
        public static string Whois(string[] masks)
        {
            string masklist = String.Join(",", masks);
            return "WHOIS " + masklist;
        }

        /// <summary>Whois message.</summary>
        public static string Whois(string target, string mask)
        {
            return "WHOIS " + target + " " + mask;
        }

        /// <summary>Whois message.</summary>
        public static string Whois(string target, string[] masks)
        {
            string masklist = String.Join(",", masks);
            return "WHOIS " + target + " " + masklist;
        }

        /// <summary>Whowas message.</summary>
        public static string Whowas(string nickname)
        {
            return "WHOWAS " + nickname;
        }

        /// <summary>Whowas message.</summary>
        public static string Whowas(string[] nicknames)
        {
            string nicknamelist = String.Join(",", nicknames);
            return "WHOWAS " + nicknamelist;
        }

        /// <summary>Whowas message.</summary>
        public static string Whowas(string nickname, string count)
        {
            return "WHOWAS " + nickname + " " + count + " ";
        }

        /// <summary>Whowas message.</summary>
        public static string Whowas(string[] nicknames, string count)
        {
            string nicknamelist = String.Join(",", nicknames);
            return "WHOWAS " + nicknamelist + " " + count + " ";
        }

        /// <summary>Whowas message.</summary>
        public static string Whowas(string nickname, string count, string target)
        {
            return "WHOWAS " + nickname + " " + count + " " + target;
        }

        /// <summary>Whowas message.</summary>
        public static string Whowas(string[] nicknames, string count, string target)
        {
            string nicknamelist = String.Join(",", nicknames);
            return "WHOWAS " + nicknamelist + " " + count + " " + target;
        }

        /// <summary>Kill message.</summary>
        public static string Kill(string nickname, string comment)
        {
            return "KILL " + nickname + " :" + comment;
        }

        /// <summary>Ping message.</summary>
        public static string Ping(string server)
        {
            return "PING " + server;
        }

        /// <summary>Ping message.</summary>
        public static string Ping(string server, string server2)
        {
            return "PING " + server + " " + server2;
        }

        /// <summary>Pong message.</summary>
        public static string Pong(string server)
        {
            return "PONG " + server;
        }

        /// <summary>Pong message.</summary>
        public static string Pong(string server, string server2)
        {
            return "PONG " + server + " " + server2;
        }

        /// <summary>Error message.</summary>
        public static string Error(string errormessage)
        {
            return "ERROR :" + errormessage;
        }

        /// <summary>Away message.</summary>
        public static string Away()
        {
            return "AWAY";
        }

        /// <summary>Away message.</summary>
        public static string Away(string awaytext)
        {
            return "AWAY :" + awaytext;
        }

        /// <summary>Rehash message</summary>
        public static string Rehash()
        {
            return "REHASH";
        }

        /// <summary>Die message.</summary>
        public static string Die()
        {
            return "DIE";
        }

        /// <summary>Restart message.</summary>
        public static string Restart()
        {
            return "RESTART";
        }

        /// <summary>Summon message.</summary>
        public static string Summon(string user)
        {
            return "SUMMON " + user;
        }

        /// <summary>Summon message.</summary>
        public static string Summon(string user, string target)
        {
            return "SUMMON " + user + " " + target;
        }

        /// <summary>Summon message.</summary>
        public static string Summon(string user, string target, string channel)
        {
            return "SUMMON " + user + " " + target + " " + channel;
        }

        /// <summary>Users message.</summary>
        public static string Users()
        {
            return "USERS";
        }

        /// <summary>Users message.</summary>
        public static string Users(string target)
        {
            return "USERS " + target;
        }

        /// <summary>Wallops message.</summary>
        public static string Wallops(string wallopstext)
        {
            return "WALLOPS :" + wallopstext;
        }

        /// <summary>Userhost message.</summary>
        public static string Userhost(string nickname)
        {
            return "USERHOST " + nickname;
        }

        /// <summary>Userhost message.</summary>
        public static string Userhost(string[] nicknames)
        {
            string nicknamelist = String.Join(" ", nicknames);
            return "USERHOST " + nicknamelist;
        }

        /// <summary>Ison message.</summary>
        public static string Ison(string nickname)
        {
            return "ISON " + nickname;
        }

        /// <summary>Ison message.</summary>
        public static string Ison(string[] nicknames)
        {
            string nicknamelist = String.Join(" ", nicknames);
            return "ISON " + nicknamelist;
        }

        /// <summary>Quit message.</summary>
        public static string Quit()
        {
            return "QUIT";
        }

        /// <summary>Quit message.</summary>
        public static string Quit(string quitmessage)
        {
            return "QUIT :" + quitmessage;
        }

        /// <summary>Squit message.</summary>
        public static string Squit(string server, string comment)
        {
            return "SQUIT " + server + " :" + comment;
        }
    }
}