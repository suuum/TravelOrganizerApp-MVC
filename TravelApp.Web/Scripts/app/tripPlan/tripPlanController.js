
angular.module('myApp').controller('CarouselDemoCtrl', function ($scope) {
    function CarouselDemoCtrl($scope) {
        $scope.myInterval = 3000;
        $scope.noWrapSlides = false;
        $scope.active = 0;
        $scope.slides = [
          {
              image: 'http://lorempixel.com/400/200/'
          },
          {
              image: 'http://lorempixel.com/400/200/food'
          },
          {
              image: 'http://lorempixel.com/400/200/sports'
          },
          {
              image: 'http://lorempixel.com/400/200/people'
          }
        ];
    }
});