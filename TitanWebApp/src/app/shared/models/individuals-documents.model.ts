import { DocumentType } from '../models/document-types.model';

export class IndividualDocument {
    constructor(
    ID: number,
    DocumentTypeID: number,
    DocumentCode: string,
    ExpeditionDate?: Date,
    ExpirationDate?: Date,
    FilePath?: string) {}
}