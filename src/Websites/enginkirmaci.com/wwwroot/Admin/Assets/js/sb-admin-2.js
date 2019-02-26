$(function () {
    $('#side-menu').metisMenu();
});

//Loads the correct sidebar on window load,
//collapses the sidebar on window resize.
// Sets the min-height of #page-wrapper to window size
$(function () {
    $(window).bind("load resize", function () {
        topOffset = 50;
        width = (this.window.innerWidth > 0) ? this.window.innerWidth : this.screen.width;
        if (width < 768) {
            $('div.navbar-collapse').addClass('collapse');
            topOffset = 100; // 2-row-menu
        } else {
            $('div.navbar-collapse').removeClass('collapse');
        }

        height = ((this.window.innerHeight > 0) ? this.window.innerHeight : this.screen.height) - 1;
        height = height - topOffset;
        if (height < 1) height = 1;
        if (height > topOffset) {
            $("#page-wrapper").css("min-height", (height) + "px");
        }
    });

    var url = window.location;
    var element = $('ul.nav a').filter(function () {
        return this.href == url || url.href.indexOf(this.href) == 0;
    }).addClass('active').parent().parent().addClass('in').parent();
    if (element.is('li')) {
        element.addClass('active');
    }
});

$(function () {
    $(".tree").treemenu().openActive();
});

// Initialize your tinyMCE Editor with your preferred options
tinyMCE.init({
    // General options
    mode: "textareas",
    theme: "modern",
    // Theme options
    theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,|,styleselect,formatselect,fontselect,fontsizeselect",
    theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
    theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
    theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,template,blockquote,pagebreak,|,insertfile,insertimage",
    theme_advanced_toolbar_location: "top",
    theme_advanced_toolbar_align: "left",
    theme_advanced_statusbar_location: "bottom",
    theme_advanced_resizing: true,

    force_br_newlines: false,
    force_p_newlines: false,
    forced_root_block: '',
    //Customized
    toolbar1: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | forecolor backcolor | bullist numlist outdent indent | link image |  preview code | fullscreen",
    menu: {
        file: { title: 'File', items: 'newdocument print' },
        edit: { title: 'Edit', items: 'undo redo | cut copy paste pastetext | selectall | searchreplace' },
        insert: { title: 'Insert', items: 'link image | charmap hr anchor pagebreak insertdatetime' },
        view: { title: 'View', items: 'visualchars visualblocks visualaid | preview code | fullscreen ' },
        format: { title: 'Format', items: 'bold italic underline strikethrough superscript subscript | formats | removeformat' },
        table: { title: 'Table', items: 'inserttable tableprops deletetable | cell row column' },
    },
    plugins: [
        "advlist autolink lists link image charmap print preview hr anchor pagebreak",
        "searchreplace wordcount visualblocks visualchars code fullscreen",
        "insertdatetime media nonbreaking save table contextmenu directionality",
        "emoticons template paste textcolor colorpicker textpattern"
    ],
    language: 'tr',
    image_advtab: true,
    statusbar: false,
    height: 300,
    file_browser_callback: RoxyFileBrowser,
});
function RoxyFileBrowser(field_name, url, type, win) {
    var roxyFileman = '/admin/assets/fileman/index.html';
    if (roxyFileman.indexOf("?") < 0) {
        roxyFileman += "?type=" + type;
    }
    else {
        roxyFileman += "&type=" + type;
    }
    roxyFileman += '&input=' + field_name + '&value=' + win.document.getElementById(field_name).value;
    if (tinyMCE.activeEditor.settings.language) {
        roxyFileman += '&langCode=' + tinyMCE.activeEditor.settings.language;
    }
    tinyMCE.activeEditor.windowManager.open({
        file: roxyFileman,
        title: 'File Explorer',
        width: 850,
        height: 650,
        resizable: "yes",
        plugins: "media",
        inline: "yes",
        close_previous: "no"
    }, { window: win, input: field_name });
    return false;
}

$(function () {
    $("[data-toggle='tooltip']").tooltip();
});

$(function () {
    $('.nav-tabs a:first').tab('show')
});

$(function () {
    window.closeModal = function () {
        $('.modal').modal('hide');
    };
})

$(function () {
    var slugUrl = $(".slugUrl").val();
    slugUrl = ConvertToSlugUrl(slugUrl);
    $(".slugUrlHtml").html(slugUrl);
    $(".slugUrlValue").val(slugUrl);

    $(".slugUrl").keyup(function () {
        var Text = $(this).val();
        Text = ConvertToSlugUrl(Text);

        $(".slugUrlHtml").html(Text);
        $(".slugUrlValue").val(Text);
    });
});

$(function () {
    $("[data-confirm-text]").click(function (e) {
        var $el = $(this);
        e.preventDefault();

        var confirmText = $el.attr('data-confirm-text');

        bootbox.confirm(confirmText, function (result) {
            if (result) {
                var form = $el.closest('form');

                var input = $("<input>").attr("type", "hidden").attr("name", $el.attr("name")).val('1');
                form.append(input);

                //form.attr("action", $el.attr("name"));
                form.submit();
            }
        });
    });
});

$(function () {
    var selectControls = $("select");

    selectControls.each(function () {
        var selectedValue = $(this).data("selected");

        $(this).val(selectedValue);

        // $("option:eq(" + selectedValue + ")", this).prop('selected', true);
    });
});

//Checkbox submit fix
$(function () {
    var checkboxes = $("[type=checkbox]");

    checkboxes.before(function () {
        return "<input type='hidden' name='" + this.name + "' value='" + this.checked + "' />";
    });

    checkboxes.change(function () {
        $(this).prev().val(this.checked);
    });
});

function ConvertToSlugUrl(text) {
    if (text == null)
        return text;

    return ConvertTurkishChars(text)
        .toLowerCase()
        .replace(/ /g, '-')
        .replace(/[^\w-]+/g, '');
}

function ConvertTurkishChars(text) {
    var olds = ["Ğ", "ğ", "Ü", "ü", "Ş", "ş", "İ", "ı", "Ö", "ö", "Ç", "ç"];
    var news = ["G", "g", "U", "u", "S", "s", "I", "i", "O", "o", "C", "c"];

    if (text != null)
        for (var i = 0; i < olds.length; i++)
            text = text.replace(olds[i], news[i]);

    return text;
}

function RemoveSrc(controlId) {
    $('#' + controlId).attr('src', '');
    $('#' + controlId + "Hidden").val('');
}