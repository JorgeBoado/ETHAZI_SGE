<%@ Page Title="" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Maps.aspx.vb" Inherits="Maps" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <br />
    <br />
    <div class="row">
        <div class="col-4">
        </div>
        <div class="col-4">
            <asp:Label ID="nameTi" runat="server" CssClass="h1"></asp:Label>
        </div>
        <div class="col-4">
        </div>
    </div>
    <br />
    <br />
    <div class="row">
        <div class="col-1">
        </div>
        <div class="col-10">
            <div style='overflow: hidden; height: 600px; width: 100%;'>
                <div id='gmap_canvas' style='visibility:visible !important;height: 600px; width: 100%;'></div>
                <style>
                    #gmap_canvas{
                        visibility:visible !important;
                    }
                    #gmap_canvas img {
                        max-width: none !important;
                        background: none !important;
                        
                    }
                </style>
            </div>
        </div>
        <div class="col-1">
        </div>
    </div>
    <br />
    <br />
    <asp:Button ID="btn_volver" runat="server" Text="Volver" CssClass="btn btn-success" />

    <script src='https://maps.googleapis.com/maps/api/js?v=3.exp&key=AIzaSyASq8YmttACgZGX3HVwu-8eB37gtmhYqmY'></script>
    <script type='text/javascript' src='https://embedmaps.com/google-maps-authorization/script.js?id=90618ad7fb561a698b3c0704fe6443dbc6b77a0b'></script>
    <script type='text/javascript'>
        function init_map(name, address, postalcode, lat, lon) {
            var myOptions = {
                zoom: 15,
                center: new google.maps.LatLng(lat, lon),
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            map = new google.maps.Map(document.getElementById('gmap_canvas'), myOptions);
            marker = new google.maps.Marker({ map: map, position: new google.maps.LatLng(lat, lon) });
            infowindow = new google.maps.InfoWindow({ content: '<strong>' + name + '</strong><br>' + address + '<br>' + postalcode + '<br>' });
            google.maps.event.addListener(marker, 'click',
                function () {
                    infowindow.open(map, marker);
                });
            infowindow.open(map, marker);
        }
    </script>
</asp:Content>

