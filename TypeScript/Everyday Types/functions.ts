export { };

function greet(name: string): string {
    return "Hello, " + name.toUpperCase() + "!!";
}

function getFavoriteNumber(): number {
    return 42;
}

console.log(greet((42).toString()));
console.log(getFavoriteNumber()); 