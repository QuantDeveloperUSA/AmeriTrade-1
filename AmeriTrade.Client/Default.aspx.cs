using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AmeriTrade.API;

namespace AmeriTrade.Client
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            API.AmeriTrade ameritrade = new API.AmeriTrade();
            Authentication autenticacao = new Authentication
            {
                clientId = "HHKGHH1YBLOHCVLNY1JINTK7LMWULUM0",
                host = "localhost",
                port = "44387",
                uri = "https"
            };

            if (!IsPostBack)
            {
                var url = Request.Url.AbsoluteUri;

                if (!url.Contains("?code="))
                {
                    Response.Redirect(ameritrade.retornarUrlAutenticacao(autenticacao));
                }
                else
                {
                    pnlOpcao.Visible = true;
                    //Autenticação usuário para pegar o Bearer Token
                    var code = Server.UrlEncode(Request.QueryString["code"].ToString());
                    var dadosAutenticacao = ameritrade.AutenticarUsuario(code, autenticacao);

                    if ( !string.IsNullOrEmpty(dadosAutenticacao.error))
                    {
                        Response.Write(dadosAutenticacao.error);
                    }
                    else
                    {
                        var listaAutenticacao = ameritrade.GetAccounts("positions", dadosAutenticacao.access_token);
                        var detalheAutenticacao = ameritrade.GetAcount(489118213, "positions", dadosAutenticacao.access_token);
                    }
                }
            }
        }

        protected void chkGetAccounts_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGetAccounts.Checked == true)
            {
                chkGetAccount.Checked = false;
            }
            else
            {
                chkGetAccount.Checked = true;
            }
        }

        protected void chkGetAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGetAccount.Checked == true)
            {
                chkGetAccounts.Checked = false;
            }
            else
            {
                chkGetAccounts.Checked = true;
            }
        }
    }
}