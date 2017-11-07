angular.module('myApp').controller('favouriteCtrl', function ($scope, $http) {
    var self = this;
    $scope.isReadonly = true;

    $http({
        method: "GET",
        url: "/Favourite/GetAttractionsByUserId"
    }).then(function mySucces(response) {
        self.attractions = response.data;
        alert(self.attractions[0].Name);
        var sum = "";
        angular.forEach(self.attractions, function (value, key) {
            var sum = 0;
            var count = 0;
            angular.forEach(value.Ranks, function (v, k) {
                sum += parseInt(v.Number, 10);
                count++;
            });
            value.Rank = parseInt(sum / count, 10);
        });

        self.sum = sum;
    }, function myError(response) {
        self.attractions = response.statusText;
    });
});