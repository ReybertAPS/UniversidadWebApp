<%@ Page Title="Asignaturas" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Asignaturas.aspx.cs" Inherits="WebApp.Pages.Asignaturas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updatePanel" UpdateMode="Always" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="title">
                    <p>ASIGNATURAS</p>
                </div>
                <div class="container-fluid card">
                    <div class="row">
                        <div class="col-sm-11">
                            <label>Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="w-100" />
                        </div>
                        <div class="col-sm-1" style="padding-top: 30px">
                            <asp:Button Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click" runat="server" CssClass="btn-success rounded" />
                        </div>
                    </div>

                    <div class="pt-4">
                        <div class="Scroll">
                            <asp:GridView ID="gvAsignaturas" runat="server" AutoPostBack="true" AutoGenerateColumns="false" CssClass="table">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="#" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                </Columns>
                                <EmptyDataTemplate>
                                    <p>No hay datos para mostrar</p>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
