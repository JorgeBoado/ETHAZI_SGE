require([
         "esri/WebScene",
         "esri/layers/FeatureLayer",
         "esri/views/SceneView",
         "esri/widgets/Legend"
], function (
         WebScene,
         FeatureLayer,
         SceneView,
         Legend
       ) {

    // Load the webscene with buildings

    var webscene = new WebScene({
        portalItem: { // autocasts as new PortalItem()
            id: "711ddecedece4fd88b728bfe4322c22b"
        }
    });

    var view = new SceneView({
        container: "viewDiv",
        map: webscene,
        basemap: "streets",
        scale:50000,
        center: [-2.92, 43.28],
        environment: {
            lighting: {
                directShadowsEnabled: true,
                ambientOcclusionEnabled: true
            }
        }
    });

    // verticalOffset shifts the symbol vertically
    var verticalOffset = {
        screenLength: 40,
        maxWorldLength: 200,
        minWorldLength: 35
    };

    // Function that automatically creates the symbol for the points of interest
    function getUniqueValueSymbol(name, color) {
        // The point symbol is visualized with an icon symbol. To clearly see the location of the point
        // we displace the icon vertically and add a callout line. The line connects the offseted symbol with the location
        // of the point feature.
        return {
            type: "point-3d", // autocasts as new PointSymbol3D()
            symbolLayers: [{
                type: "icon", // autocasts as new IconSymbol3DLayer()
                resource: {
                    href: name
                },
                size: 20,
                outline: {
                    color: "white",
                    size: 2
                }
            }],

            verticalOffset: verticalOffset,

            callout: {
                type: "line", // autocasts as new LineCallout3D()
                color: "white",
                size: 2,
                border: {
                    color: color
                }
            }
        };
    }

    var pointsRenderer = {
        type: "unique-value", // autocasts as new UniqueValueRenderer()
        field: "Type",
        uniqueValueInfos: [{
            value: "Museum",
            symbol: getUniqueValueSymbol("Museum.png", "#D13470")
        }, {
            value: "Restaurant",
            symbol: getUniqueValueSymbol("Restaurant.png", "#F97C5A")
        }, {
            value: "Church",
            symbol: getUniqueValueSymbol("Church.png", "#884614")
        }, {
            value: "Hotel",
            symbol: getUniqueValueSymbol("Hotel.png", "#56B2D6")
        }, {
            value: "Park",
            symbol: getUniqueValueSymbol("Park.png", "#40C2B4")
        }]
    };

    // Create the layer with the points of interest
    // Initially points are aligned to the buildings with relative-to-scene,
    // feature reduction is set to "selection" to avoid overlapping icons.
    // A perspective view is enabled on the layers by default.
    var pointsLayer = new FeatureLayer({
        url: "http://services.arcgis.com/V6ZHFr6zdgNZuVG0/arcgis/rest/services/LyonPointsOfInterest/FeatureServer",
        title: "Touristic attractions",
        elevationInfo: {
            // elevation mode that will place points on top of the buildings or other SceneLayer 3D objects
            mode: "relative-to-scene"
        },
        renderer: pointsRenderer,
        outFields: ["*"],
        // feature reduction is set to selection because our scene contains too many points and they overlap
        featureReduction: {
            type: "selection"
        },
        labelingInfo: [{
            labelExpressionInfo: {
                value: "{Name}"
            },
            symbol: {
                type: "label-3d", // autocasts as new LabelSymbol3D()
                symbolLayers: [{
                    type: "text", // autocasts as new TextSymbol3DLayer()
                    material: {
                        color: "white"
                    },
                    // we set a halo on the font to make the labels more visible with any kind of background
                    halo: {
                        size: 1,
                        color: [50, 50, 50]
                    },
                    size: 10
                }]
            }
        }]
    });

    webscene.add(pointsLayer);

    // add functionality on the controls for selection, perspective, callout lines and relative-to-scene elevation mode
    document.getElementById("cityStyle").addEventListener("change", function (event) {
        if (event.target.id === "declutter") {
            var type = {
                type: "selection"
            };
            pointsLayer.featureReduction = event.target.checked ? type : null;
        } else if (event.target.id === "perspective") {
            pointsLayer.screenSizePerspectiveEnabled = event.target.checked;
        } else if (event.target.id === "callout") {
            var renderer = pointsLayer.renderer.clone();
            renderer.uniqueValueInfos.forEach(function (valueInfo) {
                valueInfo.symbol.verticalOffset = event.target.checked ? verticalOffset : null;
            });
            pointsLayer.renderer = renderer;
        } else if (event.target.id === "relative-to-scene") {
            var mode = event.target.checked ? "relative-to-scene" : "relative-to-ground";
            pointsLayer.elevationInfo = {
                mode: mode
            };
        }
    });
    view.ui.add(document.getElementById("cityStyle"), "bottom-left");

    var legend = new Legend({
        view: view
    });

    view.ui.add(legend, "top-right");
});