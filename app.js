// create the first module binding is done by instruction ng-app
(function(){
	var app = angular.module('MambaClient', []);


	//Controller is created into the application
	app.controller('JawBoneDataController', [ '$scope','$http', '$templateCache', function($scope,$http,$templateCache){		

		this.indicator = 0;	
		this.settings = JawBoneAppliSettings;	
		this.AuthCode = "Empty";
		this.token = "Not Received";

		this.callApi = function(passedBy){
			this.indicator = passedBy;			
		};

		this.getCode = function(){
			var url = JawBoneAppliSettings.codeURL + "?response_type=code";			
			url += "&client_id=" + JawBoneAppliSettings.client_id;
			url += "&redirect_uri=" + JawBoneAppliSettings.redirect_uri;
			url += "&scope=" + JawBoneAppliSettings.accessScope;
			console.log(url);
			$scope.method = 'GET';
    		$scope.url = url;



			$http({method: $scope.method, url: $scope.url, cache: $templateCache});		 

		};

		this.exchangeWithToken = function(){
			var url = JawBoneAppliSettings.tokenUrl + "?";			
			url += "&grant_type=" + JawBoneAppliSettings.grantType;
			url += "&client_id=" + JawBoneAppliSettings.client_id;
			url += "&client_secret=" + JawBoneAppliSettings.client_secret;
			url += "&code=" + this.AuthCode
			console.log(url);

			$http({method: $scope.method, url: $scope.url, cache: $templateCache})
       		 .then(function(response) {       		 	
        		$scope.status = response.status;
          		$scope.data = response.data;
        	}, function(response) {
         		$scope.data = response.data || "Request failed";
          		$scope.status = response.status;
     		});
		};
		
		this.GetHeartRates = function(){			
			var url = JawBoneAppliSettings.heartRateURL			
			console.log(url);

			$http({method: 'GET', url: url, headers: {'Authorization': 'Bearer DudD7GQwFncCHRAb5pF8gw95gTmRLI9P54I9YwCfEZWhH1OZ7w66TxO6JXerpJjbQvHJd8YC72EHSTJPM-CQwVECdgRlo_GULMgGZS0EumxrKbZFiOmnmAPChBPDZ5JP'} })
       // 		 .success(function(response) {       		 	
       //  		$scope.status = response.status;
       //    		$scope.data = response.data;
       //  	})
       // 		 .error(function(response) {
       //   		$scope.data = response.data || "Request failed";
       //    		$scope.status = response.status;
     		// });
		}


	}]);	



var JawBoneAppliSettings = {
	 	name: '',
	 	vendor: 'Mamba',
	 	client_id: '',
	 	client_secret: '',
	 	codeURL:'https://jawbone.com/auth/oauth2/auth',
	 	tokenUrl:'https://jawbone.com/auth/oauth2/token',
	 	heartRateURL: 'https://jawbone.com/nudge/api/v.1.1/users/@me/heartrates',
	 	redirect_uri: 'http://localhost:9000',
	 	grantType: 'authorization_code',
	 	accessScope: 'heartrate_read'
	 };	


})();