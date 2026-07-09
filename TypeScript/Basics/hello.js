// This is an industrial-grade general-purpose greeter function:
function greeting(person, date) {
    console.log(`Hello ${person}, today is ${date.toDateString()}!`);
}
greeting("Brendan", new Date());
export {};
