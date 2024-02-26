import React, { useMemo } from 'react';
import Table from './Table';

function ModelOutputDoc({ documents, onDocumentClick }) {

    const columns = useMemo(
        () => [
            {
                Header: 'Внутренний рег. №',
                accessor: 'registrationNumber',
            },
            {
                Header: 'Дата',
                accessor: 'date',
            },
            {
                Header: 'Создатель',
                accessor: 'created',
            },
            {
                Header: 'Комментарий',
                accessor: 'publicComment',
            },
            {
                Header: 'Вид документа',
                accessor: 'typeDoc',
            },
            {
                Header: 'Личный комментарий',
                accessor: 'privateComment',
            },
        ],
        []
    );

    return <Table columns={columns} data={documents} onDocumentClick={(documentId)=>onDocumentClick(documentId)} ></Table>;
}

export default ModelOutputDoc;
