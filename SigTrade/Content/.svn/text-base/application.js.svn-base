// initialise plugins
$(function() {



    //DROP DOWNS
    $('ul.sf-menu').superfish();

    //NICE FONTS
    //Cufon.replace("h2, h3, legend");

    //TABLESORTER IS LIVE TO SURVIVE AJAX REPLACEMENT
    $("#sortedTable").livequery(function() {
        $(this).tablesorter({ widgets: ['zebra'] });
    });

    //Increasing the size of the searchbox
    $('#searchspecies').addClass("searchbox");

    $('table.tablesorter tbody td').hover(function() {
        $(this).parent().children('td').css("color", "red");
    }, function() {
        $(this).parent().children('td').css("color", "#3d3d3d");
    });
    //VALIDATION
    $.validator.setDefaults({
        success: "valid"
    });

    //Datepicker default values
    $.datepicker.setDefaults({
        dateFormat: 'd MM, yy',
        altFormat: 'dd-mm-yyyy'
    });

    // $.datepicker.setDefaults($.datepicker.regional['uk']);

    //DATEPICKER
    // $("#datepicker").datepicker({ dateFormat: 'dd-mm-yyyy' });

    $(".datepicker").livequery(function() {
        $(this).datepicker();
    });

    //$(".datepicker").datepicker({ dateFormat: 'd MM, yy' });

    //REGISTRATION
    $("a#advanced_reg_link").click(function() {
        $("div#advanced_reg").slideToggle("slow");
        return false;
    });

    $("#valid_form").validate();
    //$("#commentForm").validate();

    //Toggle the color of the links of the setLocale 
    $('.locale_link').livequery(function() {
        $(this).click(function() {
            $(this).toggleClass('color_locale');
        })
    })

    //TOOLTIP SETUP
    $('a.tooltip').cluetip({
        splitTitle: '|',
        showTitle: false,
        arrows: true,
        waitImage: true,
        fx: {
            open: 'fadeIn', // can be 'show' or 'slideDown' or 'fadeIn'
            openSpeed: 'fast'
        },
        hoverIntent: {
            sensitivity: 3,
            interval: 100,
            timeout: 10
        }
    });

    //autocomplete for searching the species
    $('#searchspecies').autocomplete('/SearchReview/Lookup', {
        dataType: 'json',
        parse: function(data) {
            var rows = new Array();
            for (var i = 0; i < data.length; i++) {
                rows[i] = { data: data[i], value: data[i].TaxonName, result: data[i].TaxonName };
            }
            return rows;
        },
        formatItem: function(row, i, n) {
            return row.TaxonName;
        },
        width: 300,
        minChars: 3,
        max: 100,
        mustMatch: true
    });

    //colors
    $("tr.list_yellow td").css("background-color", "#FFF6BF");
    $("tr.list_yellow td").css("border-bottom", "1px solid #FFD324");
    $("tr.list_yellow td").css("font-weight", "bold");
    $("tr.list_grey td, tr.list_grey td a").css("color", "#CC66CC");
    $("tr.list_green td").css("background-color", "#E6EFC2");
    $("tr.list_green td").css("border-bottom", "1px solid #C6D880");
    $("tr.list_green td").css("font-weight", "bold");


    //FADING FLASH INFORMATION
    setTimeout(function() {
        $('#flash').fadeOut("slow");
    }, 5000);

    //USER DELETE CHECK
    $(".delete_confirm").click(function() {
        return confirm("Are you sure you want to delete?");
    });


    //AJAX FORM FOR ADDING USERS TO ROLES
    $("#add_user_to_role").ajaxForm({
        target: '#roles_to_user_table_holder'
    });

    $("#add_comment").ajaxForm({
        target: '#display_comments_holder'
    });

    //    //AJAX FORM FOR ADDING USERS TO ROLES
    //    $("#AddComment").ajaxForm({
    //        target: '#display_comments_holder'
    //    });

    $(".add_new_document").livequery(function() {
        $(this).ajaxForm({
            target: '#display_documents_holder'
        });
    });


    //    $(".add_new_comment").livequery(function() {
    //        $(this).ajaxForm({
    //            target: '#display_comments_holder'

    //        });
    //    });

    //AJAX FORM FOR DELETING USERS FROM ROLES
    $(".remove_user_from_role").livequery(function() {
        $(this).ajaxForm({
            target: '#roles_to_user_table_holder',
            beforeSubmit: remove_user_from_role_check
        });
    });


    //AJAX FORM FOR DELETING COMMENTS
    $(".delete_comment_control").livequery(function() {
        $(this).ajaxForm({
            target: '#display_comments_holder',
            beforeSubmit: delete_something_check
        });
    });


    //AJAX FORM FOR DELETING REVIEWS
    $(".delete_a_review").livequery(function() {
        $(this).ajaxForm({
            target: '#list_reviews_display',
            beforeSubmit: delete_something_check
        });
    });


    //AJAX FOR DELETING DOCUMENTS
    $(".delete_document_control").livequery(function() {
        $(this).ajaxForm({
            target: '#display_documents_holder',
            beforeSubmit: delete_something_check
        });
    });


    //AJAX FOR DELETING RECOMMENDATIONS
    $(".delete_recomm_control").livequery(function() {
        $(this).ajaxForm({
            target: '#recommendations_display',
            beforeSubmit: delete_something_check
        });
    });

    //AJAX FOR DELETING DECISIONS
    $(".delete_decision_control").livequery(function() {
        $(this).ajaxForm({
            target: '#decisions_holder',
            beforeSubmit: delete_something_check
        });
    });


    //Deleting a review
    $(".delete_review_control").livequery(function() {
        $(this).submit(function() {
            return confirm('Are you sure you want to delete?')
        });
    });


    //AJAX FOR EDITING DECISIONS
    $(".edit_decision_control").livequery(function() {
        $(this).ajaxForm({
            target: '#decisions_holder'
            // beforeSubmit: delete_something_check
        });
    });

    //AJAX FOR EDITING DECISIONS
    $(".save_edited_decision").livequery(function() {
        $(this).ajaxForm({
            target: '#decisions_holder'
            //beforeSubmit: delete_something_check
        });
    });


    //AJAX FOR ADDING RECOMMENDATIONS
    $(".add_new_recommendation").livequery(function() {
        $(this).ajaxForm({
            target: '#recommendations_display'
            //beforeSubmit: delete_something_check
        });
    });

    //AJAX FOR ADDING RECOMMENDATIONS
    $(".add_new_decision").livequery(function() {
        $(this).ajaxForm({
            target: '#decisions_holder'
            // beforeSubmit: delete_something_check
        });
    });


    //    $(".add_recommendation").livequery(function() {
    //        $(this).ajaxForm({
    //        target: '#recommendations_display'            
    //        });
    //    });   

    function delete_something_check(formData, jqForm, options) {
        return confirm('Are you sure you want to delete?');
    }


    function check_deadline_date(formData, jqForm, options) {

        var queryString = $.param(formData);
        return confirm('Deadline date will default to 30days from starting paragraph date!\n\n' + queryString);
    }


    function remove_user_from_role_check(formData, jqForm, options) {
        return confirm('Are you sure you want to remove the user from this role?');
    }

    //problem with Firefox4 and input='image' submit
    $('#image_search1').click(function() {
        //alert('I was clicked');
        $('#searchForm').append('<input type="hidden" name="search_free" value="search1" />').submit();
    });

//testing why radio button is not working with Firefox

//    $(':radio').click(function() {
//        var radioID = $(this).attr('id');
//        if (radioID == 'animal_radio') {
//            alert(radioID);
//        } else if (radioID == 'plant_radio') {
//        alert(radioID);
//        } 
//    });

    //SEARCH.aspx
    $("#advanced_box h6 a").click(function() {
        $("#advanced_controls").toggle("fast");
        return false;
    });

    if ($("select#country_id option[selected=selected]").val() == null) {
        $('select#country_id').addOption("-1", "-- Select Country --");
    }

    $('#lblNoSearchResults').hide();

    $('#acountries').attr("disabled", true);

    $('#phase').prepend($('<option></option').val("-2").html("- Select All -")).selectOptions("-2");
    //$('#phase').addOption("-2", "-Select All-");

    //$('#searchcountry').addOption("-1", "Choose from List");
    $('#searchcountry').prepend($('<option></option').val("-2").html("- Select All -"));
    // $('#searchcountry').addOption("-2", "-Select All-");
    $('#searchcountry').selectOptions("-2");

    //$('#agenus').addOption("-1", "Choose from List");
    $('#agenus').prepend($('<option></option').val("-2").html("- Select All -"));
    //$('#agenus').addOption("-2", "-Select All-");
    $('#agenus').selectOptions("-2");

    //$('#aspecies').addOption("-1", "Choose from List");
    $('#aspecies').prepend($('<option></option').val("-2").html("- Select All -"));
    //$('#aspecies').addOption("-2", "-Select All-");
    $('#aspecies').selectOptions("-2");

    $("input[name='kingdom']").click(function() {

        $('#agenus').attr("disabled", true);
        $('#agenus').selectOptions("-2");
        $('#aspecies').attr("disabled", true);
        $('#aspecies').selectOptions("-2");
        $('#acountries').attr("disabled", true);
        $('#acountries').selectOptions("-2");


        var kingdom = $("input[name='kingdom']:checked").val();

        if (kingdom == "all") {
            $('#agenus').attr("disabled", true);
            $('#agenus').selectOptions("-2");
            $('#aspecies').attr("disabled", true);
            $('#aspecies').selectOptions("-2");
            $('#acountries').removeAttr("disabled");

            $.getJSON("/SearchReview/GetCountriesSearch", { ajax: true, speciesID: 0, kingdom: $("input[name='kingdom']:checked").val() }, function(data) {

                $('#acountries').attr("disabled", true);
                $('#acountries').selectOptions("-2");
                //   alert("On JSON genus works" + data[0].TaxonName);
                $('#acountries').removeOption(/./);

                var values = '';
                //$('#acountries').addOption("-1", "Choose from List");
                // $('#acountries').addOption("-2", "Select All");
                $('#acountries').prepend($('<option></option').val("-2").html("- Select All -"));
                for (i = 0; i < data.length; i++) {
                    $('#acountries').addOption(data[i].RecId, data[i].TaxonName);
                }

                //$('#species').addOption(myOptions, false);
                // $('#countries').selectOptions($(this).selectedValues, true);
                $('#acountries').selectOptions("-2");
                $('#acountries').removeAttr("disabled");
            });
        };

        if (kingdom != "all") {
            $.getJSON("/SearchReview/GetGenusSearch", { ajax: true, value: $("input:[name='kingdom']:checked").val() }, function(data) {

                //  alert("On JSON genus works" + data[0].TaxonName);
                $('#agenus').removeOption(/./);
                var values = '';
                //$('#agenus').addOption("-1", "Choose from List");
                // $('#agenus').addOption("-2", "-Select All-");
                $('#agenus').prepend($('<option></option').val("-2").html("- Select All -"));
                for (i = 0; i < data.length; i++) {
                    $('#agenus').addOption(data[i].RecId, data[i].TaxonName);
                }

                //$('#species').addOption(myOptions, false);
                $('#agenus').selectOptions("-2");
                $('#agenus').removeAttr("disabled");
                //$('#genus').selectOptions($(this).selectedValues, true);

            });
        };
        $(this).blur();

    });


    //when the genus is selected, update the species list
    $('#agenus').change(function() {
        $.getJSON("/SearchReview/GetSpeciesSearch", { ajax: true, genusID: $(this).selectedValues(), kingdom: $("input:radio[@name='kingdom']:checked").val() }, function(data) {

            $('#aspecies').attr("disabled", true);
            $('#aspecies').selectOptions("-2");
            //   alert("On JSON genus works" + data[0].TaxonName);
            $('#aspecies').removeOption(/./);
            var values = '';
            //$('#aspecies').addOption("-1", "Choose from List");
            $('#aspecies').prepend($('<option></option').val("-2").html("- Select All -"));

            // $('#aspecies').addOption("-2", "-Select All-");
            for (i = 0; i < data.length; i++) {
                $('#aspecies').addOption(data[i].RecId, data[i].TaxonName);
            }
            $('#aspecies').selectOptions("-2");
            // $('#species').selectOptions($(this).selectedValues, true);
            $('#aspecies').removeAttr("disabled");
            // $('#asubspecies').removeAttr("disabled");

        });
        //  alert("On Alert genus works");
    });

    //when the species is selected, update country
    $('#aspecies').change(function() {
        $.getJSON("/SearchReview/GetCountriesSearch", { ajax: true, speciesID: $(this).selectedValues(), kingdom: $("input:radio[@name='kingdom']:checked").val() }, function(data) {

            $('#acountries').attr("disabled", true);
            $('#acountries').selectOptions("-2");
            //   alert("On JSON genus works" + data[0].TaxonName);
            $('#acountries').removeOption(/./);

            var values = '';
            //$('#acountries').addOption("-1", "Choose from List");
            $('#acountries').prepend($('<option><option>').val("-2").html("- Select All - "));
            // $('#acountries').addOption("-2", "-Select All-");
            for (i = 0; i < data.length; i++) {
                $('#acountries').addOption(data[i].RecId, data[i].TaxonName);
            }

            //$('#species').addOption(myOptions, false);
            // $('#countries').selectOptions($(this).selectedValues, true);
            $('#acountries').selectOptions("-2");
            $('#acountries').removeAttr("disabled");
        });
    });

    //hide the all of the element with class msg_body
    $(".msg_body").hide();
    //toggle the componenet with class msg_body
    $(".msg_head").click(function() {
        $(this).next(".msg_body").slideToggle(400);
        return false;
    });

    $(function() {
        $("#tabs").tabs({
            deselectable: true
        });
    });


    var options = {
        beforeSubmit: function(formData) {
            formData.push({ name: 'ajax_submit', value: '1' });
        }
    };

    //recommendations.ascx

    $("formmodal").ajaxForm(options);



});
 
