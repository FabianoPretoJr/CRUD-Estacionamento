<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Controle.aspx.cs" Inherits="CRUD_Estacionamento.UI.Controle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 128px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <center>
            <h1>Estacionamento do Fabian</h1>
            <table>
            <tr>
                <td>
                    <table>
                        <tr>
                            <td class="auto-style1"><b>Cadastro</b></td>
                        </tr>
                                                <tr>
                         <td> Id:<asp:Label ID="lblId" runat="server" Text=""></asp:Label><br/></td>
                        </tr>
                        <tr>
                             <td class="auto-style1"><asp:TextBox ID="txtPlaca" runat="server" placeholder="Placa" MaxLength="8"></asp:TextBox></td>
                        </tr>
                        <tr>
                             <td class="auto-style1"><asp:TextBox ID="txtFabricante" runat="server" placeholder="Fabricante"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><asp:TextBox ID="txtModelo" runat="server" placeholder="Modelo"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td class="auto-style1"><asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click"/></td>
                        </tr>
                    </table>
                </td>
            </tr>
            </table>
            <hr/>

            <asp:TextBox ID="txtBusca" runat="server" placeholder="Buscar Pela Placa"></asp:TextBox>
            <asp:Button ID="btnBusca" runat="server" Text="Buscar" OnClick="btnBusca_Click"></asp:Button>

            <hr />

            <asp:GridView ID="gvListar" runat="server" OnRowCommand="gvListar_RowCommand">
                <Columns>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btnExcluir" runat="server" CausesValidation="false" CommandName="cmdExcluir" Text="Excluir" commandArgument='<%#Eval("ID")%>' OnClientClick="return confirm('Deseja realmente excluir?')"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:Button ID="btnAtualizar" runat="server" CausesValidation="false" CommandName="cmdAtualizar" Text="Atualizar" commandArgument='<%#Eval("ID")%>'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                </asp:GridView>
            </center>
        </div>
    </form>
</body>
</html>
