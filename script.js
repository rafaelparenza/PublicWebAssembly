

function base64ToBlob(base64) {
    const byteCharacters = atob(base64); 
    const byteArrays = [];

    for (let offset = 0; offset < byteCharacters.length; offset += 512) {
        const slice = byteCharacters.slice(offset, offset + 512);

        const byteNumbers = new Array(slice.length);
        for (let i = 0; i < slice.length; i++) {
            byteNumbers[i] = slice.charCodeAt(i);
        }

        const byteArray = new Uint8Array(byteNumbers);
        byteArrays.push(byteArray);
    }

    return new Blob(byteArrays, { type: 'application/octet-stream' });
}
window.BlazorDownloadFile = {
    saveAsFile: function (filename, dataBase64) {
        const link = document.createElement('a');
        link.download = filename;

        // Cria um blob a partir dos dados base64
        const blob = base64ToBlob(dataBase64);
        const url = window.URL.createObjectURL(blob);

        link.href = url;
        document.body.appendChild(link);
        link.click();

        // Limpa o objeto URL
        window.URL.revokeObjectURL(url);
        document.body.removeChild(link);
    }
};
window.exibirPrompt = function (mensagem) {
    return prompt(mensagem);
};
window.exibirAlerta = function (mensagem) {
    alert(mensagem);
};

window.cookieFunctions = {
    getCookie: function (key) {
        return document.cookie.replace(new RegExp("(?:(?:^|.*;\\s*)" + key + "\\s*\\=\\s*([^;]*).*$)|^.*$"), "$1");
    },
    setCookie: function (key, value, expireDays) {
        var expires = "";
        if (expireDays) {
            var date = new Date();
            date.setTime(date.getTime() + (expireDays * 24 * 60 * 60 * 1000));
            expires = "; expires=" + date.toUTCString();
        }
        document.cookie = key + "=" + (value || "") + expires + "; path=/";
    },
    removeCookie: function (key) {
        document.cookie = key + '=; Max-Age=-99999999;';
    }
};
window.interop = {
    getAllJsonFiles: async function () {
        const response = await fetch('/Jogos');
        const jsonFiles = await response.json();
        return jsonFiles;
    }
};
