<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaLivros.aspx.cs" Inherits="View.ListaLivros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button ID="btnNovo" runat="server" Text="Novo" /><br /><br />

            <asp:GridView ID="GdvLivros" runat="server" AutoGenerateColumns="false" AllowSorting="true" OnRowCommand="GdvLivros_RowCommand">
                <Columns>
                    <asp:BoundField DataField="id" HeaderText="Id" SortExpression="id" />
                    <asp:BoundField DataField="nome" HeaderText="Nome" SortExpression="nome" />
                    <asp:BoundField DataField="genero" HeaderText="Gênero" SortExpression="genero" />

                    <asp:TemplateField HeaderText="Ações">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>' CommandName="alterar">Alterar</asp:LinkButton>
                            <asp:LinkButton runat="server" CommandArgument='<%#DataBinder.Eval(Container.DataItem,"id") %>' CommandName="excluir">Excluir</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

            <asp:Label ID="lblMsg" runat="server" Text="" Visible="false"></asp:Label>

        </div>
    </form>
</body>
</html>
