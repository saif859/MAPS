function OnlyNumber(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;

    return true;
}
function isNumberWithDot(txt) {
    if ((event.keyCode > 47 && event.keyCode < 58) || event.keyCode == 46 || 32 == event.keyCode) {
        var txtbx = document.getElementById(txt.id);
        var amount = document.getElementById(txt.id).value;
        var present = 0;
        var count = 0;

        if (amount.indexOf(".", present) || amount.indexOf(".", present + 1));
        {
            // alert('0');
        }
        do {
            present = amount.indexOf(".", present);
            if (present != -1) {
                count++;
                present++;
            }
        }
        while (present != -1);
        if (present == -1 && amount.length == 0 && event.keyCode == 46) {
            event.keyCode = 0;
            //alert("Wrong position of decimal point not  allowed !!");
            return false;
        }

        if (count >= 1 && event.keyCode == 46) {

            event.keyCode = 0;
            //alert("Only one decimal point is allowed !!");
            return false;
        }
        if (count == 1) {
            var lastdigits = amount.substring(amount.indexOf(".") + 1, amount.length);
            if (lastdigits.length >= 10) {
                //alert("Two decimal places only allowed");
                event.keyCode = 0;
                return false;
            }
        }
        return true;
    }
    else {
        event.keyCode = 0;
        //alert("Only Numbers with dot allowed !!");
        return false;
    }

}
function OnlyAlphabet(txt) {
    var txtbx = document.getElementById(txt);
    if (!txtbx.value.match(/^[a-zA-Z]+$/) && txtbx.value != "") {
        //frm.alphabet.value = "";
        //frm.alphabet.focus();
        //alert("Please Enter only alphabets in text");
        return false;
    }
    else return true;
}
