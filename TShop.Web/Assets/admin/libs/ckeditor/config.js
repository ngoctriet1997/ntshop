/**
 * @license Copyright (c) 2003-2018, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here.
    // For complete reference see:
    // http://docs.ckeditor.com/#!/api/CKEDITOR.config

    // The toolbar groups arrangement, optimized for two toolbar rows.
    config.toolbarGroups = [
        { name: 'clipboard', groups: ['clipboard', 'undo'] },
        { name: 'editing', groups: ['find', 'selection', 'spellchecker', 'editing'] },
        { name: 'links', groups: ['links'] },
        { name: 'insert', groups: ['insert'] },
        { name: 'forms', groups: ['forms'] },
        { name: 'tools', groups: ['tools'] },
        { name: 'document', groups: ['mode', 'document', 'doctools'] },
        { name: 'others', groups: ['others'] },
        '/',
        { name: 'basicstyles', groups: ['basicstyles', 'cleanup'] },
        { name: 'paragraph', groups: ['list', 'indent', 'blocks', 'align', 'bidi', 'paragraph'] },
        { name: 'styles', groups: ['styles'] },
        { name: 'colors', groups: ['colors'] },
        { name: 'about', groups: ['about'] }
    ];
	// Remove some buttons provided by the standard plugins, which are
	// not needed in the Standard(s) toolbar.
	

	// Simplify the dialog windows.
    config.removeDialogTabs = 'image:advanced;link:advanced';
    config.filebrowserBrowseUrl= '/Assets/admin/libs/ckfinder/ckfinder.html';
    config.filebrowserUploadUrl = '/Assets/admin/libs/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
   config.filebrowserWindowWidth= '1000';
   config.filebrowserWindowHeight= '700';
};
