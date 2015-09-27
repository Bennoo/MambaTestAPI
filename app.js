// create the first module binding is done by instruction ng-app
(function(){
	var app = angular.module('MambaClient', []);

	//Controller is created into the application
	app.controller('JawBoneDataController', function(){

		this.indicator = 0;	
		this.settings = JawBoneAppliSettings;	

		this.callApi = function(passedBy){
			this.indicator = passedBy;			
		};
		
	});	



var JawBoneAppliSettings = {
	 	name: 'MambaTestAPI',
	 	vendor: 'Mamba',
	 	client_Id: 'VLR_',
	 	app_Secret: '77dcb086a496b'
	 };	


})();