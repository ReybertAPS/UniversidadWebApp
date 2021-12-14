<%@ Page Title="Estudiantes" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Estudiantes.aspx.cs" Inherits="WebApp.Pages.Estudiantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updatePanel" UpdateMode="Always" runat="server">
        <ContentTemplate>
            <div class="container">
                <div class="title">
                    <p>ESTUDIANTES</p>
                </div>
                <div class="container-fluid card">

                    <div class="row">
                        <div class="container col-sm-6">
                            <div class="col-sm-12 pd-col-sm">
                                <label>Primer Nombre</label>
                                <asp:TextBox ID="txtPrimerNombre" runat="server" CssClass="w-100" />
                            </div>
                            <div class="col-sm-12 pd-col-sm">
                                <label>Segundo Nombre</label>
                                <asp:TextBox ID="txtSegundoNombre" runat="server" CssClass="w-100" />
                            </div>
                            <div class="col-sm-12 pd-col-sm">
                                <label>Primer Apellido</label>
                                <asp:TextBox ID="txtPrimerApellido" runat="server" CssClass="w-100" />
                            </div>
                            <div class="col-sm-12 pd-col-sm">
                                <label>Segundo Apellido</label>
                                <asp:TextBox ID="txtSegundoApellido" runat="server" CssClass="w-100" />
                            </div>
                        </div>
                        <div class="container col-sm-6">
                            <div class="col-sm-12 pd-col-sm">
                                <label>Fecha de Nacimiento</label>
                                <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="w-100" placeholder="DD/MM/YYYY" />
                            </div>
                            <div class="col-sm-12 pd-col-sm">
                                <label>Direccion</label>
                                <asp:TextBox ID="txtDireccion" runat="server" TextMode="MultiLine" Rows="6" CssClass="w-100" />
                            </div>
                        </div>
                        <div class="container pt-4">
                            <div class="col-sm-1">
                                <asp:Button Text="Guardar" ID="btnGuardar" OnClick="btnGuardar_Click" runat="server" CssClass="btn-success rounded" />
                            </div>
                        </div>
                    </div>

                    <div class="container-fluid pt-4">
                        <div class="Scroll">
                            <asp:GridView ID="gvEstudiantes" runat="server" AutoPostBack="true" AutoGenerateColumns="false" CssClass="table">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="#" HeaderStyle-CssClass="text-center hide" ItemStyle-CssClass="text-center hide" />
                                    <asp:BoundField DataField="PrimerNombre" HeaderText="Primer Nombre" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                    <asp:BoundField DataField="SegundoNombre" HeaderText="Segundo Nombre" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                    <asp:BoundField DataField="PrimerApellido" HeaderText="Primer Apellido" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                    <asp:BoundField DataField="SegundoApellido" HeaderText="Segundo Apellido" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de Nacimiento" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="Direccion" HeaderText="Direccion" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
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
