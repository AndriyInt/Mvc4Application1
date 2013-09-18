(function ($) {

    var oldCategoriesIds;
    var categoriesSelectTemplate;
    var categoryCounter = 0;

    function createCategorySelect(newName) {
        var catSelectorNew = categoriesSelectTemplate.clone();
        catSelectorNew.removeAttr("id");
        catSelectorNew.attr("name", newName);
        catSelectorNew.show();
        return catSelectorNew;
    }

    function createCategorySelectPanel(catSelectorNew) {
        // category select
        var wrapper = $("<span></span>");
        wrapper.append(catSelectorNew);

        // remove button
        var removeCategoryButton = $("<input type='button' value='X' />");
        //var removeCategoryButton = $("<span>X</span>");
        removeCategoryButton.click(function () {
            $(this).parent().remove();
        });
        wrapper.append(removeCategoryButton);

        return wrapper;
    }

    $(function () {
        var oldCategoriesStr = $("#old-categories").html();

        oldCategoriesIds = oldCategoriesStr ? oldCategoriesStr.split(",") : [];
        categoriesSelectTemplate = $("#categoriesSelectTemplateContainer").find('select');
        categoriesSelectTemplate.hide();

        var categoriesEditor = $(".categories-editor");

        for (var i = 0; i < oldCategoriesIds.length; i++) {
            var $newCategoriesSelect = createCategorySelect("category" + categoryCounter++);
            $newCategoriesSelect.val(oldCategoriesIds[i]);
            var $newCategoriesSelectWrapper = createCategorySelectPanel($newCategoriesSelect);
            $newCategoriesSelectWrapper.appendTo(categoriesEditor);
        }

        $("#add-category").click(function () {
            var $newCategoriesSelect2 = createCategorySelect("category" + categoryCounter++);
            var $newCategoriesSelectWrapper2 = createCategorySelectPanel($newCategoriesSelect2);
            $newCategoriesSelectWrapper2.appendTo(categoriesEditor);
        });
    });
})(jQuery);