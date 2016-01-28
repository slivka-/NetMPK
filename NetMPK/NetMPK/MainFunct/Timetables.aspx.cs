using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;

namespace NetMPK.MainFunct
{
    public partial class Timetables : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (NetMPKGlobalVariables.getInstance().isUserLoggedIn)
            {
                if (NetMPKGlobalVariables.getInstance().userVerified)
                {
                    String stopname = Request.QueryString["stopname"];
                    String lineString = Request.QueryString["linenumber"];
                    if (stopname != null && lineString != null)
                    {

                        titleText.InnerHtml = "Rozkład jazdy dla linii "+lineString+" na przystanku "+stopname;

                        int linenumber = int.Parse(lineString);

                        DatabaseConnection db = DatabaseConnection.getInstance();
                        db.OpenConnection();
                        List<String> startingTimes = db.getStartingTimes(linenumber, 0);
                        DIR.Text = "Kierunek 0";
                        foreach (String s in startingTimes)
                        {
                            String starttime = s.Split('|')[0];
                            String dat = s.Split('|')[1];
                            List<String> time = db.getArrivalTime(stopname, linenumber, starttime, 0);
                            if (dat.Equals("w"))
                            {
                                weekDays.InnerHtml += time[0] + "<br/>";
                            }
                            else if (dat.Equals("s"))
                            {
                                saturDays.InnerHtml += time[0] + "<br/>";
                            }
                            else
                            {
                                holykDays.InnerHtml += time[0] + "<br/>";
                            }
                        }

                        List<String> startingTimes1 = db.getStartingTimes(linenumber, 1);
                        DIR1.Text = "Kierunek 1";
                        foreach (String s1 in startingTimes1)
                        {
                            String starttime1 = s1.Split('|')[0];
                            String dat1 = s1.Split('|')[1];
                            List<String> time1 = db.getArrivalTime(stopname, linenumber, starttime1, 1);
                            if (dat1.Equals("w"))
                            {
                                weekDays1.InnerHtml += time1[0] + "<br/>";
                            }
                            else if (dat1.Equals("s"))
                            {
                                saturDays1.InnerHtml += time1[0] + "<br/>";
                            }
                            else
                            {
                                holykDays1.InnerHtml += time1[0] + "<br/>";
                            }
                        }

                        db.CloseConnection();
                    }
                    else
                    {
                        titleText.InnerHtml = "";
                        weekDays.InnerHtml = "";
                        saturDays.InnerHtml = "";
                        holykDays.InnerHtml = "";
                        weekDays1.InnerHtml = "";
                        saturDays1.InnerHtml = "";
                        holykDays1.InnerHtml = "";
                    }
                }
                else
                {
                    Response.Redirect("~/Account/ConfirmAccount.aspx");
                }
            }
            else
            {
                Response.Redirect("~/MainFunct/NotLoggedIn.aspx");
            }
        }

        protected void timeTableSearch(object sender, EventArgs e)
        { 
        Regex reg = new Regex(@"[0-9]{2,3}");
            if (reg.IsMatch(lineSearch.Text))
            {
                
                Regex regStop = new Regex(@"[^0-9\:\;\'\{\}\[\]\<\>\?\/\\\+\=\)\(\*\&\^\%\$\#\@\!\~\`]+");
                if (regStop.IsMatch(stopSearch.Text))
                {
                    Response.Redirect("Timetables.aspx?linenumber=" + lineSearch.Text + "&stopname=" + StopsSearch.searchForStop(stopSearch.Text));
                }
                else
                {
                    ErrorMessage1.Text = "Wpisz poprawną nazwe przystanku";
                }
            }
            else
            {
                ErrorMessage0.Text = "Wpisz poprawny numer linii";
            }
        }
    }
}