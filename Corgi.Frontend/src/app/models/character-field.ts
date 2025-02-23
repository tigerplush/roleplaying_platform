import { FieldType } from "../enums/field-type";
import { GetCharacterFieldDtoV1 } from "../interfaces/get-character-field-dto-v1";

export abstract class CharacterField {
  constructor(
    public id: string,
    public name: string,
    public fieldType: FieldType,
    public value: string,
    public isVisible: boolean
  ) { }

  abstract evaluate(fields: Map<string, CharacterField>): string;

  static fromDTO(dto: GetCharacterFieldDtoV1): CharacterField {
    if (dto.fieldType === FieldType.Calculated) {
      return new CalculatedField(dto.id, dto.name, FieldType.Calculated, dto.value, dto.isVisible);
    } else {
      return new InputField(dto.id, dto.name, FieldType.Input, dto.value, dto.isVisible);
    }
  }
}

export class InputField extends CharacterField {
  constructor(
    id: string,
    name: string,
    fieldType: FieldType,
    value: string,
    isVisible: boolean
  ) {
    super(id, name, fieldType, value, isVisible);
  }

  evaluate(fields: Map<string, CharacterField>): string {
    return this.value;
  }
}


export class CalculatedField extends CharacterField {

  constructor(
    id: string,
    name: string,
    fieldType: FieldType,
    value: string,
    isVisible: boolean
  ) {
    super(id, name, fieldType, value, isVisible);
  }

  evaluate(fields: Map<string, CharacterField>): string {
    const expression = this.value.replace(/\$(\w+)/g, (match, fieldName) => {
      console.log(match, fieldName);
      const field = fields.get(fieldName);
      return field ? field.evaluate(fields) : fieldName; // Default to "NaN" if field not found
    });
    try {
      return new Function(`return (${expression})`)().toString();
    }
    catch(error) {
      return `${error}`;
    }
  }
}

