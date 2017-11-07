/// <reference path="../../../angular.js" />
String.prototype.trunc = String.prototype.trunc ||
function (n) {

    // this will return a substring and 
    // if its larger than 'n' then truncate and append '...' to the string and return it.
    // if its less than 'n' then return the 'string'
    return this.length > n ? this.substr(0, n - 1) + '...' : this.toString();
};
angular.module('myApp').controller('blogCtrl', function ($scope, $http, $sce) {
    var self = this;
    $http({
        method: "GET",
        url: "/Blog/GetAllBlogs"
    }).then(function mySucces(response) {
        self.Blogs = response.data;
        angular.forEach(self.Blogs, function (value, key) {
        });
    }, function myError(response) {
        self.Blogs = response.statusText;

    });



  
});