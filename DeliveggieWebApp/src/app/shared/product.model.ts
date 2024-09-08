export class PriceReduction {
    constructor(
      public dayOfWeek: number,
      public reduction: number
    ) {}
  }
  
  export class Product {
    constructor(
      public id: string,
      public name: string,
      public entryDate: Date,
      public price: number,
      public priceReduction: PriceReduction[]
    ) {}}