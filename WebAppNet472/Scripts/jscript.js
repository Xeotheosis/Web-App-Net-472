function formatNumber(input) {
    // Elimină caracterele care nu sunt cifre sau punct
    input.value = input.value.replace(/[^\d.]/g, '');

    // Împarte valoarea în două părți: partea întreagă și partea zecimală
    var parts = input.value.split('.');

    // Asigură că nu sunt mai mult de două zecimale
    if (parts[1]) {
        parts[1] = parts[1].substring(0, 2);
    }

    // Reunim părțile pentru a obține valoarea formatată
    input.value = parts.join('.');
}

