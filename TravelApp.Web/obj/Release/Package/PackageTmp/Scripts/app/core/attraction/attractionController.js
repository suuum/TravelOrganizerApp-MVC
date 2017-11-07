angular.module('myApp').controller('attractionsCtrl', function ($scope, $http) {
    var self = this;
    $scope.rate = 7;
    $scope.max = 10;
    $scope.isReadonly = true;

    $http({
        method: "GET",
        url: "/Attraction/GetAllAttractions"
    }).then(function mySucces(response) {
        self.myWelcome = response.data;
        var sum = "";
        angular.forEach(self.myWelcome, function (value, key) {
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
        self.myWelcome = response.statusText;
    });




    //$scope.attractions = [
    // {
    //     name: 'Wulkan Wezuwiusz',
    //     shortContent: 'Kiedys koszmarnie pierdonlnał.',
    //     img: 'http://1.bp.blogspot.com/-oeGvcs_oQM4/Txqup92FaSI/AAAAAAAALqc/tvmQGQWFtWI/s1600/Mount-Vesuvius.jpg',
    //     rate: 8,         
    // },
    // {
    //     name: 'Amsterdam',
    //     shortContent: 'Blandy blanty i cofffiki i jeszcze raz blanty.',
    //     img: 'https://www.kimptonhotels.com/blog/wp-content/uploads/2016/01/Amsterdam-Canal-HERO.jpg',
    //     rate: 2, 
    //},
    // {
    //     name: 'Brugia',
    //     shortContent: 'Wenecja połnocy jaram sie w huuuuj ze ją zobacze :))).',
    //     img: 'http://bi.gazeta.pl/im/9/10973/z10973609Q,Brugia--Belgia.jpg',
    //     rate: 10,
    // }, {
    //     name: 'Brugia',
    //     shortContent: 'Wenecja połnocy jaram sie w huuuuj ze ją zobacze :))).',
    //     img: 'http://bi.gazeta.pl/im/9/10973/z10973609Q,Brugia--Belgia.jpg',
    //     rate: 10,
    // },
    //{
    //name: 'Wulkan Wezuwiusz',
    //shortContent: 'Kiedys koszmarnie pierdonlnał.',
    //img: 'http://1.bp.blogspot.com/-oeGvcs_oQM4/Txqup92FaSI/AAAAAAAALqc/tvmQGQWFtWI/s1600/Mount-Vesuvius.jpg',
    //rate: 8,         
    //},
    //];

});