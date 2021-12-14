<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Login.aspx.cs" Inherits="WebApp.Login" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>AHORA</title>
    <link href="css/sweetalert2.min.css" rel="stylesheet" />
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/font-awesome.min.css" rel="stylesheet" />
    <script src="Js/sweetalert2.min.js"></script>
    <script src="Js/jquery-3.6.0.min.js"></script>
    <script src="Js/bootstrap.min.js"></script>

    <style>
        @font-face {
            src: url('../css/static/Mulish-Light.ttf');
            font-family: dwFonnt;
        }

        body {
            font-family: 'dwFonnt';
            background-size: cover;
        }

        .main-section {
            margin: 0 auto;
            margin-top: 20%;
            padding: 0;
        }

        .modal-content {
            border: none;
            padding: 0 20px;
            box-shadow:0px 0px 13px 4px #8a8484;
            -webkit-box-shadow: 0px 0px 13px 4px #8a8484;
            -moz-box-shadow:  0px 0px 13px 4px #8a8484;
        }

        .user-img {
            margin-top: -50px;
            margin-bottom: 1%;
        }

            .user-img img {
                width: 130px;
                height: 130px;
                border-radius: 50%;
                background: white;
            }

        .user-img2 {
            margin-bottom: 1%;
        }

            .user-img2 img {
                width: 90%;
                height: 100px;
                margin-bottom: 9%;
            }

        .textbox {
            border-radius: 17px 17px 17px 17px;
        }

        .btn-primary {
            margin: 0 auto;
            font-weight: 600;
            width: 50%;
            color: #fff;
            background-color: #00c1fb;
            border-color: #00c1fb;
            margin-bottom: 4%;
            border-radius: 17px 17px 17px 17px !important;
        }
        
            .btn-primary:hover {
                color: #fff;
                background-color: #00c1fb;
                border-color: #00c1fb;
            }

            .btn-primary:not(:disabled):not(.disabled).active, .btn-primary:not(:disabled):not(.disabled):active, .show > .btn-primary.dropdown-toggle {
                color: #fff;
                background-color: #00c1fb;
                border-color: #00c1fb;
            }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="scriptManager" runat="server" />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <div class="modal-dialog text-center">
                        <div class="col-sm-10 main-section">
                            <div class="modal-content" style="background-color: #383838;">
                                <div class="col-sm-12 user-img">
                                    <img src="css/Images/avatar.jpg" />
                                </div>
                                <div class="col-sm-12 user-img2">
                                    <img src="css/Images/Logo Universidad.png" />
                                </div>
                                <form class="col-sm-12">
                                    <div class="form-group">
                                        <asp:TextBox ID="txtUser" placeholder="Ingrese el usuario" CssClass="form-control textbox text-center" runat="server" />
                                    </div>
                                    <div class="form-group" style="margin-bottom: 12%;">
                                        <asp:TextBox ID="txtPassword" placeholder="Ingrese la contraseña: 1234" TextMode="Password" CssClass="form-control textbox text-center" runat="server" />
                                    </div>
                                    <asp:Button Text="INGRESAR" ID="btnLogin" CssClass="btn btn-primary" OnClick="bntIngresar_Click" runat="server" />
                                </form>
                                <div class="col-sm-12" style="margin-top: 5%; margin-bottom: 3%;">
                                    <div class="text-center text-lg-start">
                                        <span class="text-white">Fundamentos de diseño. Copyright © 2021</span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </form>

    <script type="text/javascript">


        $(document).ready(function () {


            
        });

    </script>
</body>
</html>
