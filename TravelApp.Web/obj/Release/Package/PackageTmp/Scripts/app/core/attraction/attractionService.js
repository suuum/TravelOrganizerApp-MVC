angular.
  module('myApp').
  factory('Attraction', ['$resource',
    function($resource) {
        return $resource('attractions/:phoneId.json', {}, {
        query: {
          method: 'GET',
          params: {phoneId: 'phones'},
          isArray: true
        }
      });
    }
  ]);

