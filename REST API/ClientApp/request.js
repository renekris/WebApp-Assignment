angular.module('demo', [])
  .controller('Hello', function ($scope, $http) {
    $http.get('https://localhost:5001/api/BagWithParcels').
      then(function (response) {
        $scope.greeting = response.data;
      });
  });
