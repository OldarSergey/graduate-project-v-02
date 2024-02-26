import React, { useMemo } from 'react';
import { useTable, useFilters, useGlobalFilter, useSortBy } from 'react-table';

function Table({ columns, data, onDocumentClick, children }) {
    const {
        getTableProps,
        getTableBodyProps,
        headerGroups,
        rows,
        prepareRow,
        state,
        setGlobalFilter,
    } = useTable(
        {
            columns,
            data,
        },
        useFilters,
        useGlobalFilter,
        useSortBy
    );

    const { globalFilter } = state;

    const handleDocumentClick = (documentId) => {
        onDocumentClick(documentId);
    };

    return (
        <div>
            <div className="filter-container">
                <input
                    className="filter-input"
                    value={globalFilter || ''}
                    onChange={(e) => setGlobalFilter(e.target.value)}
                    placeholder="Поиск..."
                />
            </div>

            {children}
            
            <div className="table-wrapper mt-4 mb-4 max-h-96 overflow-auto">
                <table {...getTableProps()} className="doc-table">
                    <thead className="sticky-header">
                        {headerGroups.map((headerGroup) => (
                            <tr {...headerGroup.getHeaderGroupProps()}>
                                {headerGroup.headers.map((column) => (
                                    <th
                                        {...column.getHeaderProps(column.getSortByToggleProps())}
                                        className={column.isSorted ? (column.isSortedDesc ? 'sort-desc' : 'sort-asc') : ''}
                                    >
                                        {column.render('Header')}
                                    </th>
                                ))}
                            </tr>
                        ))}
                    </thead>
                    <tbody {...getTableBodyProps()}>
                        {rows.map((row) => {
                            prepareRow(row);
                            return (
                                <tr {...row.getRowProps()} className="hover:bg-gray-100 cursor-pointer"> {/* Добавляем класс к tr */}
                                    {row.cells.map((cell) => (
                                        <td
                                        {...cell.getCellProps()}
                                        onClick={() => handleDocumentClick(cell.row.original.id)}
                                    >
                                        {cell.column.id === 'date' ? new Date(cell.value).toLocaleDateString() : cell.render('Cell')}
                                    </td>
                                    ))}
                                </tr>
                            );
                        })}
                    </tbody>
                </table>
            </div>
        </div>
    );
}
export default Table;
