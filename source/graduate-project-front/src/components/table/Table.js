import React, { useMemo } from 'react';
import "./Table.css"
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
        <>
         <div className="filter-container" style={{position:'absolute', marginLeft:'16%',marginTop:'0.5%',width:'30%'}}>
                <input
                    className="filter-input"
                    value={globalFilter || ''}
                    onChange={(e) => setGlobalFilter(e.target.value)}
                    placeholder="Поиск..."
                />
            </div>
        <div>

           <div className="container">
               <table {...getTableProps()} className="doc-table">
                   <thead className="sticky-header">
                       {headerGroups.map((headerGroup) => (
                           <tr {...headerGroup.getHeaderGroupProps()} className='overflow-hidden'>
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
                               <tr {...row.getRowProps()} className="hover:bg-gray-100 cursor-pointer">
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
        </>
        
    );
}

export default Table;
