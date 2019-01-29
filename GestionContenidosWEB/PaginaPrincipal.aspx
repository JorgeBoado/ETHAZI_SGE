<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="PaginaPrincipal.aspx.vb" Inherits="PaginaPrincipal" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      
    <br />
    <br />
    <div class="row">
        <div class="col-md-2">
            <label>
                Filters
            </label>
        </div>
    </div>
    <div class="row">
        <div class="col-md">
            <hr />
        </div>
    </div>
    <div class="row">
        <div class="col-md-1">
            <label style="margin-left: 50px; padding-top: 20px">
                <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="true" />
            </label>
        </div>
        <div class="col-md-3">
            <label>Territory</label>
            <asp:DropDownList ID="territoryFiltro" runat="server" CssClass="form-control filt" AutoPostBack="True" Enabled="False"></asp:DropDownList>
        </div>
        <div class="col-md-3">
            <label>Municipality</label>
            <asp:DropDownList ID="municipioFiltro" runat="server" CssClass="form-control filt" AutoPostBack="True" Enabled="False"></asp:DropDownList>
        </div>
        <div class="col-md-2">
            <label>PC</label>
            <asp:DropDownList ID="CPFiltro" runat="server" CssClass="form-control filt" AutoPostBack="True" Enabled="False"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-md-1">
            <label style="margin-left: 50px; padding-top: 20px">
                <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="true" />
            </label>
        </div>
        <div class="col-md-2">
            <label>Type</label>
            <asp:DropDownList ID="TipoFiltro" runat="server" CssClass="form-control filt" AutoPostBack="True" Enabled="False"></asp:DropDownList>
        </div>
        <div class="col-md-2">
            <label>Category</label>
            <asp:DropDownList ID="CategoriaFiltro" runat="server" CssClass="form-control filt" AutoPostBack="True" Enabled="False"></asp:DropDownList>
        </div>
    </div>
    <div class="row">
        <div class="col-md-1">
            <label style="margin-left: 50px; padding-top: 20px">
                <asp:CheckBox ID="CheckBox3" runat="server" AutoPostBack="true" />
            </label>
        </div>
        <div class="col-md-3">
            <label>Name</label>
            <asp:TextBox ID="buscarFiltro" runat="server" CssClass="form-control filt" Enabled="false"></asp:TextBox>

        </div>
        <div class="col-md-2">
            <label></label>
            <asp:Button ID="btn_buscarFiltro" runat="server" Text="Search" CssClass="btn btn-primary" Enabled="false" />
        </div>
    </div>
    <hr />
    <section>
        <asp:Button ID="btn_actualizar" runat="server" Text="Update" CssClass="btn btn-primary" Enabled="False" />
        <asp:Button ID="btn_insertar" runat="server" Text="Insert" CssClass="btn btn-primary" />
        <asp:Button ID="btn_eliminar" runat="server" Text="Delete" CssClass="btn btn-primary" Enabled="False" />
        <asp:Button ID="btn_mapa" runat="server" Text="Show map" CssClass="btn btn-primary" Enabled="False" />
    </section>
    <asp:Panel ID="Panel1" runat="server">
        <br />
        <div id="tabla" style="overflow: scroll">
            <asp:GridView ID="GridView1" runat="server" Style="overflow: scroll" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                <EditRowStyle Wrap="True" Height="100px" />
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerSettings FirstPageText="1" LastPageText="" PreviousPageText="" />
                <PagerStyle BackColor="White" ForeColor="#8BC34A" HorizontalAlign="Left" />
                <SelectedRowStyle BackColor="#4caf50" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />

            </asp:GridView>
        </div> 
    </asp:Panel>
</asp:Content>


