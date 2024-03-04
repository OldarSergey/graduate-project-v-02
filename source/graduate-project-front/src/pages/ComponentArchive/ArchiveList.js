import React from 'react';

function ArchiveList({ listArchive, onArchiveClick }) {
    const handleArchiveClick = (keyNote) => {
        onArchiveClick(keyNote);
    };

    return (
        <>
            <p>Архив</p>
            <div className='mt-3' style={{ height: '90vh', overflowY: 'auto', width: '250px' }}>
                <table>
                    <tbody>
                        {listArchive.map((archive, index) => (
                            <tr key={index} onClick={() => handleArchiveClick(archive.keyNote)} className="cursor-pointer transition duration-300 ease-in-out hover:bg-gray-200">
                                <td>{archive.name}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
        </>
    );
}

export default ArchiveList;
