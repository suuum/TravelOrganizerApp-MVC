angular.module('myApp').controller('singleBlogCtrl', function ($scope, $http) {
    var self = this;

    $scope.$watch("projectId", function () {
        // I can now use projectId in whatever I want:
      
        self.projectId = $scope.projectId
        $http({
            method: "GET",
            url: "/Blog/GetSingleBlog/" + self.projectId
        })
        .then(function mySucces(response) {
            self.Blog = response.data;
        }, function myError(response) {
            self.Blog = response.statusText;
        });     

        self.submit = function () {
        
            self.createComment = {};
            self.createComment.Content = self.CommentContent;
         //   alert(self.projectId)
            self.createComment.BlogDto = {};
            self.createComment.BlogDto.Id = self.projectId;

            $http({
                url: '/Blog/CreateComment',
                method: "POST",
                data: { 'comment': self.createComment }
            })
       .then(function mySucces(response) {
          window.location.reload();

       }, function myError(response) {
           alert("wtopa");
       });
           // alert("FSDFASDf");
        };
    });

   

});

