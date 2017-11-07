angular.module('myApp').controller('tripPlanCtrl', function ($scope, $http) {
    var self = this;
  //  self.isClicked = 0;
    self.items = [];
    self.hidden = "hidden";
    $http({
        method: "GET",
        url: "/TripPlan/GetAllCountries"
    })
    .then(function mySucces(response) {
        self.Countries = response.data;
        //$scope.country = self.Countries[0];
        angular.forEach(self.Countries, function (value, key) {//kraj
            angular.forEach(value.Cities, function (v, k) {//miasto
                //pobieramy wysztkie atrakcje dla danego miata
                $http({
                    method: "GET",
                    url: "/TripPlan/GetAttractionByCityId/" + v.Id
                })
            .then(function mySucces(response) {
                v.Attractions = response.data;
                if ($scope.attraction === "") {

                    //          $scope.attraction = v.Attractions[0].Name;
                    alert($scope.attraction);
                }
            }, function myError(response) {
                self.Countries = response.statusText;

            }
            );
            });
            //$scope.city = self.Countries[0].Cities[0];        
            //$scope.attraction = self.Countries[0].Cities[0].Attractions[0].Name;

        }, function myError(response) {
            self.Countries = response.statusText;
            alert(self.Countries);
        });
    });
    self.DisplayAll = {};
    self.submit = function () {
    //    self.isClicked = 1;
        self.AttractionId = [];
        angular.forEach(self.items, function (value, key) {
            self.AttractionId.push(value.attraction.Id);
        });
        self.DisplayAll.Attractions = self.AttractionId;
        self.DisplayAll.Transport = self.Transport;
        self.DisplayAll.HoursPerDay = self.HoursPerDay;
        self.DisplayAll.Directions = $('#right-panel').html();
        $http({
            url: '/TripPlan/Create',
            method: "POST",
            data: { 'tripPlanObject': self.DisplayAll }
        })
   .then(function mySucces(response) {
       self.pdfGuid = response.data;
       self.hidden = "";

   }, function myError(response) {
       alert("error");
   });
    };


    self.downloadPdf=function(){

        var map = $("#map");
                   html2canvas(map, {
                useCORS: true,
                allowTaint: false,
                onrendered: function (canvas) {
                    alert(canvas.toDataURL('image/png'))
                    var dataUrl = canvas.toDataURL('image/png');
                    $("#ssMap").attr("src", dataUrl);

                    $(".gm-style>div:first>div").css({
                        left: 0,
                        top: 0,
                        "transform": transform
                    })
                }

            });
        
        $http({
            method: "GET",
            url: "/TripPlan/DownloadTripPlan/" + self.pdfGuid
        })
      .then(function mySucces(response) {

      }, function myError(response) {
          alert("error")
      }
      );
    }

    self.add = function () {
        var flag = 0;
        angular.forEach(self.items, function (value, key) {
            if (value.attraction.Name == $scope.attraction.Name || $scope.attraction.Name === undefined) {
                flag = 1;
            }
        });

        if (flag === 0) {
            self.items.push({
                attraction: $scope.attraction
            });
        }
        else {
            alert("Nie możesz dodać dwóch takich samych atrakcji");
        }
    };

    self.remove = function (array, index) {

        array.splice(index, 1);
    }
    self.checkAttractionLenght = function(){

        if (self.items.length >= 2) {

            return false;

        }
        else {
            return true;
        }

    };
    self.checkClicked = function () {

        //if (self.isClicked==1) {
        //    return false;
        //}
        //else {
        //    return true;
        //}

    };

    self.checkAttraction = function () {
        
        if (c == null) {
            return true;
        }
        else
            return false;
    };

    $scope.downloadFile = function (httpPath) {
        // Use an arraybuffer
        $http.get(httpPath, { responseType: 'arraybuffer' })
        .success(function (data, status, headers) {

            var octetStreamMime = 'application/octet-stream';
            var success = false;

            // Get the headers
            headers = headers();

            // Get the filename from the x-filename header or default to "download.bin"
            var filename = headers['x-filename'] || 'download.bin';

            // Determine the content type from the header or default to "application/octet-stream"
            var contentType = headers['content-type'] || octetStreamMime;

            try {
                // Try using msSaveBlob if supported
                console.log("Trying saveBlob method ...");
                var blob = new Blob([data], { type: contentType });
                if (navigator.msSaveBlob)
                    navigator.msSaveBlob(blob, filename);
                else {
                    // Try using other saveBlob implementations, if available
                    var saveBlob = navigator.webkitSaveBlob || navigator.mozSaveBlob || navigator.saveBlob;
                    if (saveBlob === undefined) throw "Not supported";
                    saveBlob(blob, filename);
                }
                console.log("saveBlob succeeded");
                success = true;
            } catch (ex) {
                console.log("saveBlob method failed with the following exception:");
                console.log(ex);
            }

            if (!success) {
                // Get the blob url creator
                var urlCreator = window.URL || window.webkitURL || window.mozURL || window.msURL;
                if (urlCreator) {
                    // Try to use a download link
                    var link = document.createElement('a');
                    if ('download' in link) {
                        // Try to simulate a click
                        try {
                            // Prepare a blob URL
                            console.log("Trying download link method with simulated click ...");
                            var blob = new Blob([data], { type: contentType });
                            var url = urlCreator.createObjectURL(blob);
                            link.setAttribute('href', url);

                            // Set the download attribute (Supported in Chrome 14+ / Firefox 20+)
                            link.setAttribute("download", filename);

                            // Simulate clicking the download link
                            var event = document.createEvent('MouseEvents');
                            event.initMouseEvent('click', true, true, window, 1, 0, 0, 0, 0, false, false, false, false, 0, null);
                            link.dispatchEvent(event);
                            console.log("Download link method with simulated click succeeded");
                            success = true;

                        } catch (ex) {
                            console.log("Download link method with simulated click failed with the following exception:");
                            console.log(ex);
                        }
                    }

                    if (!success) {
                        // Fallback to window.location method
                        try {
                            // Prepare a blob URL
                            // Use application/octet-stream when using window.location to force download
                            console.log("Trying download link method with window.location ...");
                            var blob = new Blob([data], { type: octetStreamMime });
                            var url = urlCreator.createObjectURL(blob);
                            window.location = url;
                            console.log("Download link method with window.location succeeded");
                            success = true;
                        } catch (ex) {
                            console.log("Download link method with window.location failed with the following exception:");
                            console.log(ex);
                        }
                    }

                }
            }

            if (!success) {
                // Fallback to window.open method
                console.log("No methods worked for saving the arraybuffer, using last resort window.open");
                window.open(httpPath, '_blank', '');
            }
        })
        .error(function (data, status) {
            console.log("Request failed with status: " + status);

            // Optionally write the error out to scope
            $scope.errorDetails = "Request failed with status: " + status;
        });
    };
    self.directions = function () {

        //      self.direction = $('#right-panel').html();
        //    alert(self.direction);
    }
    self.click = function () {

        //html2canvas($('#map'), {
        //     useCORS: true,
        //    onrendered: function (canvas) {
        //        alert(canvas.toDataURL());
        //        $('#Canvas').append(canvas);
        //    }
        //});
    };
});