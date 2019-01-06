(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);
    productCategoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams','commonService']
    function productCategoryEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true
        }
        $scope.getTitleSeo = getTitleSeo;
        function getTitleSeo() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }

        function loadProductCategoryDetail() {
            var config = {
                params: {
                    id: $stateParams.id
                }
            }
            apiService.get('/api/productcategory/getbyid', config, function (result) {
                $scope.productCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
                })
        }

        $scope.UpdateProductCategory = UpdateProductCategory;
        function UpdateProductCategory() {
            apiService.put('/api/productcategory/update', $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.Name + 'Đã được cập nhật thành công');
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError('Cập nhật không thành công');
            });
        }

        $scope.loadParentCategories = [];
        function loadParentCategories() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }
        loadParentCategories();
        loadProductCategoryDetail();
    }
})(angular.module('tshop.product_categories'))