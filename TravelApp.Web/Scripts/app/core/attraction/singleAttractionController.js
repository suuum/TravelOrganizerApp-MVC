angular.module('myApp').controller('singleAttractionCtrl', function ($scope, $http) {
    var self = this;

    $scope.$watch("projectId", function () {
        // I can now use projectId in whatever I want:
        self.projectId = $scope.projectId;
        $http({
            method: "GET",
            url: "/Attraction/GetSingleAttraction/" + $scope.projectId
        })
        .then(function mySucces(response) {
            self.Attraction = response.data;
        }, function myError(response) {
            self.Attraction = response.statusText;
        });

        $http({
            method: "GET",
            url: "/Attraction/GetAttractionRank/" + $scope.projectId
        })
        .then(function mySucces(response) {
            self.Attraction.UserRank = response.data.Number;
        }, function myError(response) {
            self.Attraction = response.statusText;
        });

        $http({
            method: "GET",
            url: "/Attraction/CheckIfIsFavourite/" + $scope.projectId
        })
        .then(function mySucces(response) {

            if (angular.equals(response.data, "True")) {
                self.favourite = "glyphicon glyphicon-heart";

            }
            else {
                self.favourite = "glyphicon glyphicon-heart-empty";
            }
        }, function myError(response) {
            self.Attraction = response.statusText;
        });

        self.submit = function () {

            self.createComment = {};
            self.createComment.Content = self.CommentContent;
            self.createComment.Attraction = {};
            self.createComment.Attraction.Id = self.projectId;

            $http({
                url: '/Attraction/CreateComment',
                method: "POST",
                data: { 'comment': self.createComment }
            })
                .then(function mySucces(response) {
                    window.location.reload();
                }, function myError(response) {
                    alert("wtopa");
                });
        };
        self.hoveringOver = function (value) {
            self.overStar = value;
            
        };
        self.clickForNoReason = function () { };
        self.setRating = function () {
            $http({
                method: "GET",
                url: "/Attraction/CheckIfIsRanked/" + self.projectId
            })
            .then(function mySucces(response) {
                self.Rank = {};
                self.Rank.Number = self.overStar;
                self.Rank.Number = self.Attraction.UserRank
                self.Rank.Attraction = {};
                self.Rank.Attraction.Id = self.projectId;
                if (angular.equals(response.data, "True")) {
                    $http({
                        method: "POST",
                        url: "/Attraction/ChangeRank/",
                        data: { 'rank': self.Rank }
                    }).then(function mySucces(response) {
                        alert("udało sie zmienic ranking");
                    }, function myError(response) {
                        alert("pucha");
                        self.Attraction = response.statusText;
                    });
                }
                else {
                    $http({
                        method: "Post",
                        url: "/Attraction/CreateRank/",
                        data: { 'rank': self.Rank }
                    }).then(function mySucces(response) {
                        alert("udało sie stworzyć ranking");

                    }, function myError(response) {
                        alert("pucha");
                        self.Attraction = response.statusText;
                    });
                }

            }, function myError(response) {
                self.Attraction = response.statusText;
            });

            
        };

          self.myInterval = 5000;
          self.noWrapSlides = false;
          self.active = 0;
          var slides = $scope.slides = [{}];
  var currIndex = 0;


        self.setFavourite = function () {
            if (angular.equals(self.favourite, "glyphicon glyphicon-heart-empty")) {
                $http({
                    method: "GET",
                    url: "/Attraction/CreateFavourite/" + $scope.projectId
                }).then(function mySucces(response) {
                    alert("udało sie");
                    self.favourite = "glyphicon glyphicon-heart";
                }, function myError(response) {
                    alert("pucha");
                    self.Attraction = response.statusText;
                });
            }
            else {
                $http({
                    method: "GET",
                    url: "/Attraction/RemoveFavourite/" + $scope.projectId
                }).then(function mySucces(response) {
                    alert("udało sie");
                    self.favourite = "glyphicon glyphicon-heart-empty";
                }, function myError(response) {
                    alert("pucha");
                    self.Attraction = response.statusText;
                });
            }
        };
    });
});

