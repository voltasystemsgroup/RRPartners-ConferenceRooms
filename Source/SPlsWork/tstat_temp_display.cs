using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace CrestronModule_TSTAT_TEMP_DISPLAY
{
    public class CrestronModuleClass_TSTAT_TEMP_DISPLAY : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        Crestron.Logos.SplusObjects.AnalogInput TEMPERATURE_IN_TENTHS;
        Crestron.Logos.SplusObjects.DigitalInput SHOW_HALF_DEGREES;
        Crestron.Logos.SplusObjects.StringInput APPEND_CHARS;
        Crestron.Logos.SplusObjects.StringOutput TEMPERATURE_DISPLAY__DOLLAR__;
        private ushort ROUNDEDDIVIDE (  SplusExecutionContext __context__, ushort IOPERAND , ushort IDIVISOR ) 
            { 
            ushort IQUOTIENT = 0;
            ushort IREMAINDER = 0;
            
            
            __context__.SourceCodeLine = 28;
            IQUOTIENT = (ushort) ( (IOPERAND / IDIVISOR) ) ; 
            __context__.SourceCodeLine = 29;
            IREMAINDER = (ushort) ( Mod( IOPERAND , IDIVISOR ) ) ; 
            __context__.SourceCodeLine = 31;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IREMAINDER < (IDIVISOR / 2) ))  ) ) 
                {
                __context__.SourceCodeLine = 32;
                return (ushort)( IQUOTIENT) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 34;
                return (ushort)( (IQUOTIENT + 1)) ; 
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        object TEMPERATURE_IN_TENTHS_OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort IINTPART = 0;
                ushort IFRACPART = 0;
                
                
                __context__.SourceCodeLine = 43;
                if ( Functions.TestForTrue  ( ( Functions.Not( SHOW_HALF_DEGREES  .Value ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 45;
                    TEMPERATURE_DISPLAY__DOLLAR__  .UpdateValue ( Functions.ItoA (  (int) ( ROUNDEDDIVIDE( __context__ , (ushort)( TEMPERATURE_IN_TENTHS  .UshortValue ) , (ushort)( 10 ) ) ) ) + APPEND_CHARS  ) ; 
                    } 
                
                else 
                    { 
                    __context__.SourceCodeLine = 50;
                    IINTPART = (ushort) ( (TEMPERATURE_IN_TENTHS  .UshortValue / 10) ) ; 
                    __context__.SourceCodeLine = 51;
                    IFRACPART = (ushort) ( Mod( TEMPERATURE_IN_TENTHS  .UshortValue , 10 ) ) ; 
                    __context__.SourceCodeLine = 53;
                    switch ((int)IFRACPART)
                    
                        { 
                        case 0 : 
                        case 1 : 
                        case 2 : 
                        case 3 : 
                        
                            { 
                            __context__.SourceCodeLine = 60;
                            IFRACPART = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 61;
                            break ; 
                            } 
                        
                        goto case 4 ;
                        case 4 : 
                        goto case 5 ;
                        case 5 : 
                        goto case 6 ;
                        case 6 : 
                        
                            { 
                            __context__.SourceCodeLine = 68;
                            IFRACPART = (ushort) ( 5 ) ; 
                            __context__.SourceCodeLine = 69;
                            break ; 
                            } 
                        
                        goto case 7 ;
                        case 7 : 
                        goto case 8 ;
                        case 8 : 
                        goto case 9 ;
                        case 9 : 
                        
                            { 
                            __context__.SourceCodeLine = 76;
                            IFRACPART = (ushort) ( 0 ) ; 
                            __context__.SourceCodeLine = 77;
                            IINTPART = (ushort) ( (IINTPART + 1) ) ; 
                            __context__.SourceCodeLine = 78;
                            break ; 
                            } 
                        
                        break;
                        } 
                        
                    
                    __context__.SourceCodeLine = 82;
                    TEMPERATURE_DISPLAY__DOLLAR__  .UpdateValue ( Functions.ItoA (  (int) ( IINTPART ) ) + "." + Functions.ItoA (  (int) ( IFRACPART ) ) + APPEND_CHARS  ) ; 
                    } 
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    public override object FunctionMain (  object __obj__ ) 
        { 
        try
        {
            SplusExecutionContext __context__ = SplusFunctionMainStartCode();
            
            __context__.SourceCodeLine = 90;
            APPEND_CHARS  .UpdateValue ( ""  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        
        SHOW_HALF_DEGREES = new Crestron.Logos.SplusObjects.DigitalInput( SHOW_HALF_DEGREES__DigitalInput__, this );
        m_DigitalInputList.Add( SHOW_HALF_DEGREES__DigitalInput__, SHOW_HALF_DEGREES );
        
        TEMPERATURE_IN_TENTHS = new Crestron.Logos.SplusObjects.AnalogInput( TEMPERATURE_IN_TENTHS__AnalogSerialInput__, this );
        m_AnalogInputList.Add( TEMPERATURE_IN_TENTHS__AnalogSerialInput__, TEMPERATURE_IN_TENTHS );
        
        APPEND_CHARS = new Crestron.Logos.SplusObjects.StringInput( APPEND_CHARS__AnalogSerialInput__, 2, this );
        m_StringInputList.Add( APPEND_CHARS__AnalogSerialInput__, APPEND_CHARS );
        
        TEMPERATURE_DISPLAY__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TEMPERATURE_DISPLAY__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( TEMPERATURE_DISPLAY__DOLLAR____AnalogSerialOutput__, TEMPERATURE_DISPLAY__DOLLAR__ );
        
        
        TEMPERATURE_IN_TENTHS.OnAnalogChange.Add( new InputChangeHandlerWrapper( TEMPERATURE_IN_TENTHS_OnChange_0, false ) );
        SHOW_HALF_DEGREES.OnDigitalChange.Add( new InputChangeHandlerWrapper( TEMPERATURE_IN_TENTHS_OnChange_0, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public CrestronModuleClass_TSTAT_TEMP_DISPLAY ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint TEMPERATURE_IN_TENTHS__AnalogSerialInput__ = 0;
    const uint SHOW_HALF_DEGREES__DigitalInput__ = 0;
    const uint APPEND_CHARS__AnalogSerialInput__ = 1;
    const uint TEMPERATURE_DISPLAY__DOLLAR____AnalogSerialOutput__ = 0;
    
    [SplusStructAttribute(-1, true, false)]
    public class SplusNVRAM : SplusStructureBase
    {
    
        public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
        
        
    }
    
    SplusNVRAM _SplusNVRAM = null;
    
    public class __CEvent__ : CEvent
    {
        public __CEvent__() {}
        public void Close() { base.Close(); }
        public int Reset() { return base.Reset() ? 1 : 0; }
        public int Set() { return base.Set() ? 1 : 0; }
        public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
    }
    public class __CMutex__ : CMutex
    {
        public __CMutex__() {}
        public void Close() { base.Close(); }
        public void ReleaseMutex() { base.ReleaseMutex(); }
        public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
    }
     public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
