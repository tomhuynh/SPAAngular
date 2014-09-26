module = angular.module 'app'
module.factory 'demoService', ['BASE_WEB_API','$http', '$q', (BASE_WEB_API,$http, $q) ->

    getAlerts = ->
        $http.get("#{BASE_WEB_API}/alerts").then (response) ->
            response.data
        , (errorResponse) ->
            throw { 
                status:  errorResponse.status
                message: errorResponse.data.Message
            }
    
    {
        getAlerts: getAlerts 
    }
] 