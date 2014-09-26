# CoffeeScript
app = angular.module 'app', ['ngRoute']

app.controller 'DemoCtrl', ['$scope', 'demoService'
($scope,demoService) ->

    $scope.hideRows = false
    $scope.hideRow = ->
        $scope.hideRows = !$scope.hideRows

    $scope.alerts = "loading"
    demoService.getAlerts().then (ret) ->    
        $scope.alerts = ret;
        
    $scope.closeAlert = (index) ->
       $scope.alerts.splice index,1
       
    $scope.myalert = 
      Id = 0
    
    $scope.type = ""
    
    $scope.$watch 'myalert.Id', (val) ->
        if val is 1
            $scope.type = "alert-info"
        else if val is 2
            $scope.type = "alert-warning"
        else if val is 3        
            $scope.type = "alert-danger"
            
]