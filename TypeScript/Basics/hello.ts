export { };
    
// This is an industrial-grade general-purpose greeter function:
function greeting(person: string, date: Date) {
  console.log(`Hello ${person}, today is ${date.toDateString()}!`);
}
 
greeting("Brendan",  new Date());