<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Editar.aspx.vb" Inherits="Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <section>
        <fieldset>
            <legend>Lodging</legend>
            <br />
            <section>
                <div class="form-row">
                    <div class="form-group col-md-2">
                        <label for="idAc">ID</label>
                        <asp:TextBox ID="idAc" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-5">
                        <label for="firmaAc">Signatura</label>
                        <asp:TextBox ID="firmaAc" runat="server" CssClass="form-control" Required="required"></asp:TextBox>
                    </div>  
                    <div class="form-group col-md-5">
                        <label for="nameAc">Name</label>
                        <asp:TextBox ID="nameAc" runat="server" CssClass="form-control" Required="required"></asp:TextBox>
                    </div>                 
                </div>
                <div class="form-row">
                    <div class="form-group col-md-4">
                        <label for="capacityAc">Capacity</label>
                        <asp:TextBox ID="capacityAc" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="typeAc">Type</label>
                        <asp:DropDownList ID="typeAc" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="categoryAc">Category</label>
                        <asp:DropDownList ID="categoryAc" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-row">                   
                    <div class="form-group col-md-6">
                        <label for="phoneAc">Phone</label>
                        <asp:TextBox ID="phoneAc" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="markAc">Mark</label>
                        <asp:TextBox ID="markAc" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>               
                <div class="form-row">
                    <div class="form-group col-md-6">
                        <label for="emailAc">Email</label>
                        <asp:TextBox ID="emailAc" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="webAc">Web</label>
                        <asp:TextBox ID="webAc" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>                    
                </div>
                <div class="form-row">
                    <div class="form-group col-md-8">
                        <label for="addressAc">Address</label>
                        <asp:TextBox ID="addressAc" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-4">
                        <label for="municipalityAc">Municipality</label>
                        <asp:DropDownList ID="municipalityAc" runat="server" CssClass="form-control"  AutoPostBack="True"></asp:DropDownList>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md-3">
                        <label for="cmAc">Municipality Code</label>
                        <asp:TextBox ID="cmAc" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                    </div>
                    <div class="form-group col-md-3">
                        <label for="cpAc">Postal Code</label>
                        <asp:DropDownList ID="cpAc" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="form-group col-md-6">
                        <label for="coordinateAc">Coordinates</label>
                        <asp:TextBox ID="coordinateAc" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md">
                        <label for="descripAc">Description</label>
                        <asp:TextBox ID="descripAc" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
                <div class="form-row">
                    <div class="form-group col-md">
                        <label for="friendAc">FriendlyUrl</label>
                        <asp:TextBox ID="friendAc" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>       
                </div>
                <div class="form-row">
                    <div class="form-group col-md">
                        <label for="physicalAc">PhysicalUrl</label>
                        <asp:TextBox ID="physicalAc" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>       
                </div>
                <div class="form-row">
                    <div class="form-group col-md">
                        <label for="zipAc">ZipFile</label>
                        <asp:TextBox ID="zipAc" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>       
                </div>
            </section>
        </fieldset>
    </section>
    <section>
        <div class="form-row">
            <asp:Button ID="finEditar" runat="server" Text="Save" CssClass="btn btn-success " />
            <asp:Button ID="canEditar" runat="server" Text="Cancel" CssClass="btn btn-success" />
        </div>
    </section>
</asp:Content>
