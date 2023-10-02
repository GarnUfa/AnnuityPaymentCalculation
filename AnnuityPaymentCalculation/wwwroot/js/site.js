let plholder = document.querySelector("input[name='PaymentStep']");
let loanTerm = document.querySelector("input[name='LoanTerm']");
loanTerm.oninput = function () {
    plholder.setAttribute("placeholder", "от 1 до " + loanTerm.value)
};

$.validator.methods.range = function (value, element, param) {
    var globalizedValue = value.replace(".", ",");
    return this.optional(element) || (globalizedValue >= param[0] && globalizedValue <= param[1]);
}

$.validator.methods.number = function (value, element) {
    return this.optional(element) || /^-?(?:\d+|\d{1,3}(?:[\s\.,]\d{3})+)(?:[\.,]\d+)?$/.test(value);
}