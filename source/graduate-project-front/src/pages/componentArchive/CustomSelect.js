import React from 'react';
import Select from 'react-select';

// Опции для выпадающего списка
const options = [...Array(20).keys()].map((_, index) => ({
  value: new Date().getFullYear() - index,
  label: `${new Date().getFullYear() - index}`
}));

// Компонент
// Компонент
// Компонент
const CustomSelect = ({ selectedYear, handleYearChange }) => {
  return (
    <Select
      id="year"
      value={{ value: selectedYear, label: selectedYear.toString() }}
      onChange={(selectedOption) => handleYearChange(selectedOption.value)}
      options={options}
      styles={{
        menuPortal: base => ({ ...base, zIndex: 9999 }),
        menu: base => ({
          ...base,
          maxHeight: 150, // Измените это значение на то, которое вам нужно
          overflowY: 'hidden' // Добавление скроллбара при необходимости
        })
      }}
      menuPortalTarget={document.body}
    />
  );
};



export default CustomSelect;
