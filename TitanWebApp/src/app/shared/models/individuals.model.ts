import { Gender } from './genders.model'

export class Individual {
    constructor(
        ID?: number,
        Code?: string,
        FirstName?: string,
        SecondName?: string,
        ThirdName?: string,
        FourthName?: string,
        GenderID?: number,
        Gender?: Gender,
        BirthDate?: Date) { }
}