<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/MasterPage.Master" AutoEventWireup="true" CodeBehind="Notas.aspx.cs" Inherits="WebApp.Pages.Notas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        a {
            color: black;
        }
    </style>
    <asp:UpdatePanel ID="updatePanel" UpdateMode="Always" runat="server">
        <ContentTemplate>
            <div class="pl-5 pr-5">
                <div class="title">
                    <p>NOTAS</p>
                </div>
                <div class="container-fluid card p-4">

                    <div class="row">
                        <div class="container col-sm-6">
                            <div class="col-sm-12">
                                <label class="row col-sm-12">Estudiantes</label>
                                <div class="Scroll" style="height: 280px; width: 100%">
                                    <asp:GridView ID="gvEstudiantes" runat="server" AutoPostBack="true" AutoGenerateColumns="false" CssClass="table" AutoGenerateSelectButton="true" SelectedRowStyle-ForeColor="White" SelectedRowStyle-BackColor="DarkBlue" OnSelectedIndexChanging="gvEstudiantes_SelectedIndexChanging" OnSelectedIndexChanged="gvEstudiantes_SelectedIndexChanged">
                                        <Columns>
                                            <asp:BoundField DataField="Id" HeaderText="#" HeaderStyle-CssClass="text-center hide" ItemStyle-CssClass="text-center hide" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <p>No hay datos para mostrar</p>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <div class="container col-sm-6">
                            <div class="row">
                                <div class="col-sm-12">
                                    <label class="row col-sm-12">Asignatura</label>
                                    <asp:DropDownList runat="server" ID="ddlAsignatura" CssClass="w-100" Style="height: 32px">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-12">
                                    <label class="row col-sm-12">Periodo</label>
                                    <asp:DropDownList runat="server" ID="ddlPeriodo" CssClass="w-100" Style="height: 32px">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-sm-12">
                                    <label>Fecha</label>
                                    <asp:TextBox ID="txtFecha" runat="server" CssClass="w-100" placeholder="DD/MM/YYYY" />
                                </div>
                                <div class="col-sm-12">
                                    <label class="w-100">Nota</label>
                                </div>
                                <div class="col-sm-12">
                                    <asp:TextBox ID="txtIdNota" runat="server" Style="width: 15%;" Enabled="false" />
                                    <asp:TextBox ID="txtNota" runat="server" Style="width: 84%" />
                                </div>
                                <div class="col-sm-12 row" style="padding-top: 30px">
                                    <asp:Button Text="Guardar" ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" CssClass="btn-success rounded mr-2" />
                                    <asp:Button Text="Eiminar" ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" CssClass="btn-danger rounded mr-2" />
                                    <%--<asp:Button Text="Actualizar" ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" CssClass="btn-primary rounded mr-2" />--%>
                                    <asp:Button Text="limpiar" ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" CssClass="btn-primary rounded" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="container-fluid pt-4">
                        <div class="Scroll">
                            <asp:GridView ID="gvNotas" runat="server" AutoPostBack="true" AutoGenerateColumns="false" CssClass="table" AutoGenerateSelectButton="true" SelectedRowStyle-ForeColor="White" SelectedRowStyle-BackColor="DarkBlue" OnSelectedIndexChanged="gvNotas_SelectedIndexChanged">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="#" HeaderStyle-CssClass="text-center hide" ItemStyle-CssClass="text-center hide" />
                                    <asp:BoundField DataField="Nota" HeaderText="Nota" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="IdEstudiante" HeaderText="Id Estudiante" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                    <asp:BoundField DataField="Estudiante" HeaderText="Estudiante" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                    <asp:BoundField DataField="IdAsignatura" HeaderText="Id Asignatura" HeaderStyle-CssClass="text-center d-none" ItemStyle-CssClass="text-center d-none" />
                                    <asp:BoundField DataField="Asignatura" HeaderText="Asignatura" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                    <asp:BoundField DataField="IdPeriodo" HeaderText="Id Periodo" HeaderStyle-CssClass="text-center d-none" ItemStyle-CssClass="text-center d-none" />
                                    <asp:BoundField DataField="Periodo" HeaderText="Periodo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
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
